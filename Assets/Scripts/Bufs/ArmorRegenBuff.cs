namespace Scripts.Bufs
{
    using Scripts.Components.HealthArmor;
    using UnityEngine;

    public class ArmorRegenBuff : BaseFlagWallBuff
    {
        [SerializeField] private int _armorRegen = 1;

        protected override void OnTriggered(GameObject go)
        {
            if (go.TryGetComponent<HealthArmorComponent>(out HealthArmorComponent armor))
            {
                armor.ModifyArmor(_armorRegen);
                Destroy(gameObject);
            }
        }
    }
}