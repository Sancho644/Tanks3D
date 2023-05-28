using Scripts.Components.HealthArmor;
using UnityEngine;

namespace Buffs
{
    public class ArmorRegenBuff : BaseBuff
    {
        [SerializeField] private int _armorRegen = 1;

        protected override void OnTriggered(GameObject go)
        {
            if (go.TryGetComponent<HealthArmorComponent>(out HealthArmorComponent armor))
            {
                armor.ModifyArmor(_armorRegen);
            }

            base.OnTriggered(gameObject);
        }
    }
}