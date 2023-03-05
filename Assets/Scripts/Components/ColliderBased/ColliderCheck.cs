using UnityEngine;

namespace Scripts.Components.ColliderBased
{
    public class ColliderCheck : MonoBehaviour
    {
        [SerializeField] protected string _tag;
        [SerializeField] protected LayerMask _layer;
        [SerializeField] protected bool _isTouchingLayer;

        public bool IsTochingLayer => _isTouchingLayer;
    }
}