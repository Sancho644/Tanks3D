namespace Scripts.Components.ColliderBased
{
    using UnityEngine;
    using System;

    public class BaseColliderCheck : MonoBehaviour
    {
        [SerializeField] protected CollisionStages[] _stages;
        [SerializeField] protected bool _isTouchingLayer = default;

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