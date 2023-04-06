namespace Scripts.Components.ColliderBased
{
    using UnityEngine;

    public class Checker : BaseColliderCheck
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