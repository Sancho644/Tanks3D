using Scripts.Components.ColliderBased;
using UnityEngine;

namespace Scripts.Buffs
{
    public class BaseBuff : MonoBehaviour
    {
        [SerializeField] private EnterTriggerComponent _trigger;

        private void Start()
        {
            _trigger.OnEnterTriggered += OnTriggered;
        }

        protected virtual void OnTriggered(GameObject go)
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _trigger.OnEnterTriggered -= OnTriggered;
        }
    }
}