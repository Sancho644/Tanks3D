using System.Collections;
using Model;
using Model.Data;
using Model.Definitions.LevelsDefs;
using UnityEngine;
using Utils;

namespace Components.GoBased
{
    public class RandomSpawnComponent : MonoBehaviour
    {
        [SerializeField] private LevelSettings _level;
        [SerializeField] private bool _destroyObject;
        [SerializeField] private bool _isEnemiesSpawner;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Vector3 _volume;
        [SerializeField] private Vector3 _sizeCollider;

        private int _countOfObjects;
        private Collider[] _colliders;
        private GameObject _obj;
        private Coroutine _coroutine;
        private GameSession _session;

        public void Awake()
        {
            _session = GameSession.Instance;
            _countOfObjects = _level.CountOfObjects;

            if (_isEnemiesSpawner)
            {
                if (_session.Data.EnemyesCount.Value == 0)
                {
                    CountOfEnemies.SetTotalEnemies(_countOfObjects);
                }
                else
                {
                    CountOfEnemies.SetTotalEnemies(_session.Data.EnemyesCount.Value);
                    _countOfObjects = _session.Data.EnemyesCount.Value;
                }

                CountOfEnemies.OnModify += OnStartSpawn;
            }

            _coroutine = StartCoroutine(StartSpawn());
        }

        private void OnStartSpawn()
        {
            if (_coroutine == null)
                _coroutine = StartCoroutine(StartSpawn());
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

                var spawnPosition = _spawnPoint.position;
                var position = new Vector3(Random.Range(spawnPosition.x - _volume.x, spawnPosition.x + _volume.x),
                    spawnPosition.y, Random.Range(spawnPosition.z - _volume.z, spawnPosition.z + _volume.z));

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
            var rand = Random.Range(0, _level.ObjectsPrefabs.Length);
            var rotation = _level.ObjectsPrefabs[rand].transform.rotation;

            _obj = SpawnUtils.Spawn(_level.ObjectsPrefabs[rand], position, rotation);

            if (_destroyObject)
                Destroy(_obj, _level.DestroyDelay);
        }

        private bool CheckSpawnPoint(Vector3 position)
        {
            _colliders = Physics.OverlapBox(position, _sizeCollider);

            return _colliders.Length <= 0;
        }

        private void OnDestroy()
        {
            CountOfEnemies.OnModify -= OnStartSpawn;
        }
    }
}