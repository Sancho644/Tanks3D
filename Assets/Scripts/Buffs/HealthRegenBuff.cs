namespace Scripts.Bufs
{
    using Scripts.Components.HealthArmor;
    using UnityEngine;

    public class HealthRegenBuff : BaseFlagWallBuff
    {
        [SerializeField] private int _healthRegen = 1;

        protected override void OnTriggered(GameObject go)
        {
            if (go.TryGetComponent<HealthArmorComponent>(out HealthArmorComponent health))
            {
                health.ModifyHealth(_healthRegen);
                Destroy(gameObject);
            }
        }
    }
}