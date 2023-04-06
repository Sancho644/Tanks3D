namespace Scripts.Components.ColliderBased
{
    using UnityEngine;
    using System;

    public class EnterCollisionComponent : MonoBehaviour
    {
        [SerializeField] private CollisionStages[] _stages = default;

        public event Action<string, GameObject> OnAction = default;

        private void OnCollisionEnter(Collision other)
        {
            foreach (var stage in _stages)
            {
                if (other.gameObject.CompareTag(stage.Tag))
                {
                    OnAction?.Invoke(stage.Tag, other.gameObject);
                    return;
                }
            }
        }

        [Serializable]
        public class CollisionStages
        {
            [SerializeField] private string _tag;

            public string Tag => _tag;
        }
    }
}