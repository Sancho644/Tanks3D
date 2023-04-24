using Scripts.Model.Data;
using Scripts.Model.Definitions.LevelsDefs;
using Scripts.Utils;
using System.Collections;
using UnityEngine;

namespace Scripts.Components.GoBased
{
    public class RandomSpawnComponent : MonoBehaviour
    {
        [SerializeField] private BaseLevelDef _level;
        //[SerializeField] private float _spawnDelay = 1f;
        [SerializeField] private float _destroyDelay = 2f;
        //[SerializeField] private float _startSpawnDelay = 1f;
        private int _countOfObjects = 0;
        //[SerializeField] private int _objectsInOneTime = 10;
        [SerializeField] private bool _destroyObject;
        //[SerializeField] private GameObject[] _prefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Vector3 _volume;
        [SerializeField] private Vector3 _sizeCollider;

        private Collider[] _colliders;
        private GameObject obj;
        private Coroutine _coroutine;

        public bool _startOnAwake = false;

        public void Awake()
        {
            if (_startOnAwake)
            {
                _coroutine = StartCoroutine(StartSpawn());
            }

            _countOfObjects = _level.CountOfObjects;
            CountOfEnemies.OnModify += OnModifyCount;
        }

        private void OnModifyCount()
        {
            if(_coroutine == null)
            {
                _coroutine = StartCoroutine(StartSpawn());
            }
        }

        private IEnumerator StartSpawn()
        {
            yield return new WaitForSeconds(_level.StartSpawnDelay);

            while (_countOfObjects > 0)
            {               
                if (CountOfEnemies.Count == _level.ObjectsInOneTime)
                {
                    _coroutine = null;
                    Debug.Log("enemycount");
                    yield break;
                }

                var position = new Vector3(Random.Range(_spawnPoint.position.x - _volume.x, _spawnPoint.position.x + _volume.x),
                _spawnPoint.position.y,
                Random.Range(_spawnPoint.position.z - _volume.z, _spawnPoint.position.z + _volume.z));

                if (CheckSpawnPoint(position))
                {
                    Spawn(position);

                    _countOfObjects--;

                    yield return new WaitForSeconds(_level.SpawnDelay);
                }
                else
                {
                    yield return null;
                }
            }
        }

        private void Spawn(Vector3 position)
        {
            int rand = Random.Range(0, _level.ObjectsPrefabs.Length);
            var rotation = _level.ObjectsPrefabs[rand].transform.rotation;

            obj = SpawnUtils.Spawn(_level.ObjectsPrefabs[rand], position, rotation);

            if (_destroyObject)
            {
                Destroy(obj, _destroyDelay);
            }
        }

        private bool CheckSpawnPoint(Vector3 position)
        {
            _colliders = Physics.OverlapBox(position, _sizeCollider);

            return _colliders.Length > 0 ? false : true;
        }
    }
}