using System;
using UnityEngine;

namespace Components.ColliderBased
{
    public class EnterCollisionComponent : BaseColliderCheck
    {
        public event Action<string, GameObject> OnAction;

        private void OnCollisionEnter(Collision other)
        {
            foreach (var stage in _stages)
            {
                if (other.gameObject.CompareTag(stage.Tag))
                {
                    _isTouchingLayer = true;
                    OnAction?.Invoke(stage.Tag, other.gameObject);

                    return;
                }
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            _isTouchingLayer = false;
        }
    }
}