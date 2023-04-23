using UnityEngine;
using System;

namespace Scripts.Components.ColliderBased
{
    public class BaseColliderCheck : MonoBehaviour
    {
        [SerializeField] protected CollisionStages[] _stages;
        [SerializeField] protected bool _isTouchingLayer;

        public bool IsTochingLayer => _isTouchingLayer;

        [Serializable]
        public class CollisionStages
        {
            [SerializeField] protected string _tag = default;
            [SerializeField] protected LayerMask _layer = ~0;

            public string Tag => _tag;
            public LayerMask Layer => _layer;
        }
    }
}