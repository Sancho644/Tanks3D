using UnityEngine;
using System;

namespace Scripts.Components.GoBased
{
    public class ActiveObjectComponent : MonoBehaviour
    {
        [SerializeField] private Prefabs[] _prefabs;

        [ContextMenu("Spawn")]
        public void SetActiveObject()
        {
            foreach (var item in _prefabs)
            {
                item.Prefab.SetActive(true);
            }
        }
    }

    [Serializable]
    public struct Prefabs
    {
        public GameObject Prefab;
        public Transform Target;
    }
}