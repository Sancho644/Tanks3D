using Scripts.Utils;
using System.Collections;
using UnityEngine;

namespace Scripts.Components.GoBased
{
    public class RandomSpawnComponent : MonoBehaviour
    {
        [SerializeField] private float _spawnDelay = 1f;
        [SerializeField] private float _destroyDelay = 2f;
        [SerializeField] private float _startSpawnDelay = 1f;
        [SerializeField] private int _countOfObjects = 10;
        [SerializeField] private bool _destroyObject;
        [SerializeField] private GameObject[] _prefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Vector3 _volume;
        [SerializeField] private Vector3 _sizeCollider;

        private Collider[] _colliders;
        private bool _checkCollision;
        private GameObject obj;

        public void Awake()
        {
            StartCoroutine(SpawnField());
        }

        private IEnumerator SpawnField()
        {
            yield return new WaitForSeconds(_startSpawnDelay);

            int i = 0;

            while (i < _countOfObjects)
            {
                var position = new Vector3(Random.Range(_spawnPoint.position.x - _volume.x, _spawnPoint.position.x + _volume.x),
                _spawnPoint.position.y,
                Random.Range(_spawnPoint.position.z - _volume.z, _spawnPoint.position.z + _volume.z));

                _checkCollision = CheckSpawnPoint(position);

                if (_checkCollision)
                {
                    int rand = Random.Range(0, _prefab.Length);
                    var rotation = _prefab[rand].transform.rotation;

                    obj = SpawnUtils.Spawn(_prefab[rand], position, rotation);

                    if (_destroyObject)
                    {
                        Destroy(obj, _destroyDelay);
                    }

                    i++;

                    yield return new WaitForSeconds(_spawnDelay);
                }
                else
                {
                    yield return null;
                }
            }
        }

        private bool CheckSpawnPoint(Vector3 position)
        {
            _colliders = Physics.OverlapBox(position, _sizeCollider);

            return _colliders.Length > 0 ? false : true;
        }
    }
}