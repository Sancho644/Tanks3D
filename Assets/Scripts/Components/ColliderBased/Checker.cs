using UnityEngine;
using Utils;

namespace Components.ColliderBased
{
    public class Checker : BaseColliderCheck
    {
        private void OnTriggerStay(Collider other)
        {
            foreach (var stage in _stages)
            {
                if (other.gameObject.IsInLayer(stage.Layer))
                {
                    _isTouchingLayer = true;
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