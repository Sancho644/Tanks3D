using Scripts.Components.Audio;
using Scripts.Components.ColliderBased;
using UnityEngine;

namespace Buffs
{
    public class BaseBuff : MonoBehaviour
    {
        [SerializeField] private EnterTriggerComponent _trigger;
        
        protected PlaySoundsComponent _sounds;

        private void Start()
        {
            _trigger.OnEnterTriggered += OnTriggered;
            _sounds = GetComponent<PlaySoundsComponent>();
        }

        protected virtual void OnTriggered(GameObject go)
        {
            _sounds.Play("Up");
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _trigger.OnEnterTriggered -= OnTriggered;
        }
    }
}