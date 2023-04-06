namespace Scripts.Components.ColliderBased
{
    using System;
    using UnityEngine;

    public class EnterTriggerComponent : MonoBehaviour
    {
        [SerializeField] private string _tag = default;
        [SerializeField] private LayerMask _layer = ~0;

        public event Action<GameObject> OnEnterTriggered = default;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.IsInLayer(_layer)) return;
            if (!string.IsNullOrEmpty(_tag) && !other.gameObject.CompareTag(_tag)) return;

            OnEnterTriggered?.Invoke(other.gameObject);
        }
    }
}