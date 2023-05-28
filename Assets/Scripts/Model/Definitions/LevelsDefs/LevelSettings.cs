using UnityEngine;

namespace Model.Definitions.LevelsDefs
{
    [CreateAssetMenu(menuName = "Defs/LevelSettings", fileName = "LevelSettings")]
    public class LevelSettings : ScriptableObject
    {
        [SerializeField] private GameObject[] _objectsPrefabs;
        [SerializeField] private int _countOfObjects = 50;
        [SerializeField] private int _objectsInOneTime = 5;
        [SerializeField] private float _spawnDelay = 1f;
        [SerializeField] private float _startSpawnDelay = 1f;

        public GameObject[] ObjectsPrefabs => _objectsPrefabs;
        public int CountOfObjects => _countOfObjects;
        public int ObjectsInOneTime => _objectsInOneTime;
        public float SpawnDelay => _spawnDelay;
        public float StartSpawnDelay => _startSpawnDelay;
    }
}