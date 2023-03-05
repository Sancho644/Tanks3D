using UnityEngine.Events;
using UnityEngine;
using System;

namespace Scripts.Components.ColliderBased
{
    public class EnterCollisionComponent : MonoBehaviour
    {
        [SerializeField] private CollisionStages[] _stages;

        private void OnCollisionEnter(Collision other)
        {
            foreach (var stage in _stages)
            {
                if (other.gameObject.CompareTag(stage.Tag))
                {
                    stage.Action?.Invoke(other.gameObject);
                    return;
                }
            }
        }

        [Serializable]
        public class CollisionStages
        {
            [SerializeField] private string _tag;
            [SerializeField] private EnterEvent _action;

            public string Tag => _tag;
            public EnterEvent Action => _action;
        }
    }

    [Serializable]
    public class EnterEvent : UnityEvent<GameObject>
    {
    }
}