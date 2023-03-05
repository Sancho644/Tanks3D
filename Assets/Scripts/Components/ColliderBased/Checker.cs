using UnityEngine;

namespace Scripts.Components.ColliderBased
{
    public class Checker : ColliderCheck
    {
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.IsInLayer(_layer))
            {
                _isTouchingLayer = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.IsInLayer(_layer))
            {
                _isTouchingLayer = false;
            }
        }
    }
}