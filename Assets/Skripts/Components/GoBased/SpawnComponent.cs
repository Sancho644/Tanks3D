using UnityEngine;
using Skripts.Utils;

namespace Skripts.Components
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private GameObject _alternativePrefab;

        public void SpawnPrefab()
        {
            SpawnUtils.Spawn(_prefab, _target.position, _target.rotation); 
        }

        public void SpawnAlternativePrefab()
        {
            SpawnUtils.Spawn(_alternativePrefab, _target.position, _target.rotation);
        }
    }
}