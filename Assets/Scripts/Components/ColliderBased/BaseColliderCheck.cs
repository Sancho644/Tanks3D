namespace Scripts.Components.ColliderBased
{
    using UnityEngine;

    public class BaseColliderCheck : MonoBehaviour
    {
        [SerializeField] protected string _tag = default;
        [SerializeField] protected LayerMask _layer = default;
        [SerializeField] protected bool _isTouchingLayer = default;

        public bool IsTochingLayer => _isTouchingLayer;
    }
}