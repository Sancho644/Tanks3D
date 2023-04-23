using Scripts.Utils;
using System;
using UnityEngine;

namespace Scripts.Components.ColliderBased
{
    public class Checker : BaseColliderCheck
    {
        public event Action<GameObject> OnEnterCheck;

        private void OnTriggerStay(Collider other)
        {
            foreach (var stage in _stages)
            {
                if (other.gameObject.IsInLayer(stage.Layer))
                {
                    _isTouchingLayer = true;
                    OnEnterCheck?.Invoke(other.gameObject);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            foreach (var stage in _stages)
            {
                if (other.gameObject.IsInLayer(stage.Layer))
                {
                    _isTouchingLayer = false;
                }
            }
        }
    }
}