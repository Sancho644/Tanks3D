using System;
using UnityEngine;
using Utils;

namespace Components.ColliderBased
{
    public class EnterTriggerComponent : MonoBehaviour
    {
        [SerializeField] protected string _tag;
        [SerializeField] protected LayerMask _layer = ~0;
        [SerializeField] protected bool _isTouchingLayer;

        public bool IsTouchingLayer => _isTouchingLayer;
        public event Action<GameObject> OnEnterTriggered;

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