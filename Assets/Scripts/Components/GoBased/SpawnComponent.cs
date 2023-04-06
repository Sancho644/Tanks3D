namespace Scripts.Components.GoBased
{
    using UnityEngine;
    using Scripts.Utils;

    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target = default;
        [SerializeField] private GameObject _prefab = default;
        [SerializeField] private GameObject _alternativePrefab = default;

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