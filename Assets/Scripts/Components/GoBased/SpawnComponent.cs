using Scripts.Utils;
using UnityEngine;

namespace Components.GoBased
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private GameObject _alternativePrefab;

        public void Spawn()
        {
            SpawnUtils.Spawn(_prefab, _target.position, _target.rotation); 
        }

        public void AlternativeSpawn()
        {
            SpawnUtils.Spawn(_alternativePrefab, _target.position, _target.rotation);
        }
    }
}