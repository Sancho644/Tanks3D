using Scripts.Components.HealthArmor;
using UnityEngine;

namespace Scripts.Buffs
{
    public class HealthRegenBuff : BaseBuff
    {
        [SerializeField] private int _healthRegen = 1;

        protected override void OnTriggered(GameObject go)
        {
            if (go.TryGetComponent<HealthArmorComponent>(out HealthArmorComponent health))
            {
                health.ModifyHealth(_healthRegen);
            }

            base.OnTriggered(gameObject);
        }
    }
}