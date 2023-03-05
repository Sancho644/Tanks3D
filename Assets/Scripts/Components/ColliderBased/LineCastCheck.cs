using UnityEngine;

namespace Scripts.Components.ColliderBased
{
    public class LineCastCheck : ColliderCheck
    {
        [SerializeField] private float _distance;

        private RaycastHit hit;

        void Update()
        {
            Ray ray = new Ray(transform.position, transform.forward);
            Debug.DrawRay(transform.position, transform.forward * _distance);

            if (Physics.Raycast(ray, out hit, _distance))
            {
                _isTouchingLayer = hit.collider.gameObject.IsInLayer(_layer);
            }
            else 
            {
                _isTouchingLayer = false;
            }
        }
    }
}