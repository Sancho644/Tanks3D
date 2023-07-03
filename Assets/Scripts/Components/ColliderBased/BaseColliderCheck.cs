using System;
using UnityEngine;

namespace Components.ColliderBased
{
    public class BaseColliderCheck : MonoBehaviour
    {
        [SerializeField] protected CollisionStages[] _stages;
        [SerializeField] protected bool _isTouchingLayer;

        public bool IsTouchingLayer => _isTouchingLayer;

        public void SetTouchingLayer(bool value)
        {
            _isTouchingLayer = value;
        }

        [Serializable]
        public class CollisionStages
        {
            [SerializeField] protected string _tag;
            [SerializeField] protected LayerMask _layer;

            public string Tag => _tag;
            public LayerMask Layer => _layer;
        }
    }
}