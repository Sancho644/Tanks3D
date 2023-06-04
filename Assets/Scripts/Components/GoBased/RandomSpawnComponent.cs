using Scripts.Model.Data;
using Scripts.Utils;
using System.Collections;
using Model.Data;
using Model.Definitions.LevelsDefs;
using UnityEngine;

namespace Scripts.Components.GoBased
{
    public class RandomSpawnComponent : MonoBehaviour
    {
        [SerializeField] private LevelSettings _level;
        [SerializeField] private float _destroyDelay = 2f;
        [SerializeField] private bool _destroyObject;
        [SerializeField] private bool _isEnemiesSpawner;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Vector3 _volume;
        [SerializeField] private Vector3 _sizeCollider;

        private int _countOfObjects = 0;
        private Collider[] _colliders;
        private GameObject _obj;
        private Coroutine _coroutine;

        public void Awake()
        {
            _countOfObjects = _level.CountOfObjects;

            if (_isEnemiesSpawner)
            {
                CountOfEnemies.SetTotalEnemies(_countOfObjects);
                CountOfEnemies.OnModify += OnStartSpawn;
            }
            _coroutine = StartCoroutine(StartSpawn());
        }

        private void OnStartSpawn()
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(StartSpawn());
            }
        }

        private IEnumerator StartSpawn()
        {
            yield return new WaitForSeconds(_level.StartSpawnDelay);

            while (_countOfObjects > 0)
            {
                if (_isEnemiesSpawner && CountOfEnemies.Count == _level.ObjectsInOneTime)
                {
                    _coroutine = null;

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

            _obj = SpawnUtils.Spawn(_level.ObjectsPrefabs[rand], position, rotation);

            if (_destroyObject)
            {
                Destroy(_obj, _destroyDelay);
            }
        }

        private bool CheckSpawnPoint(Vector3 position)
        {
            _colliders = Physics.OverlapBox(position, _sizeCollider);

            return _colliders.Length > 0 ? false : true;
        }

        private void OnDestroy()
        {
            CountOfEnemies.OnModify -= OnStartSpawn;
        }
    }
}