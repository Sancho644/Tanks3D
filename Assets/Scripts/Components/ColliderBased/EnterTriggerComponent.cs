namespace Scripts.Components.ColliderBased
{
    using System;
    using UnityEngine;

    public class EnterTriggerComponent : MonoBehaviour
    {
        [SerializeField] protected string _tag = default;
        [SerializeField] protected LayerMask _layer = ~0;
        [SerializeField] protected bool _isTouchingLayer = default;

        public bool IsTochingLayer => _isTouchingLayer;
        public event Action<GameObject> OnEnterTriggered = default;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.IsInLayer(_layer)) return;
            if (!string.IsNullOrEmpty(_tag) && !other.gameObject.CompareTag(_tag)) return;

            _isTouchingLayer = true;

            OnEnterTriggered?.Invoke(other.gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            _isTouchingLayer = false;
        }
    }
}