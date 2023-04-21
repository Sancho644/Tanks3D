namespace Scripts.Bufs
{
    using Scripts.Components.ColliderBased;
    using UnityEngine;

    public class BaseFlagWallBuff : MonoBehaviour
    {
        [SerializeField] private EnterTriggerComponent _trigger = default;

        private void Start()
        {
            _trigger.OnEnterTriggered += OnTriggered;
        }

        protected virtual void OnTriggered(GameObject go)
        {
            var list = FlagWalls.Instance;

            foreach (var objects in list.BrickWalls)
            {
                objects.SetActive(true);
            }

            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _trigger.OnEnterTriggered -= OnTriggered;
        }
    }
}