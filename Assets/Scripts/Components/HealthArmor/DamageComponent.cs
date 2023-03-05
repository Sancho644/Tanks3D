using UnityEngine;

namespace Scripts.Components.HealthArmor
{
    public class DamageComponent : MonoBehaviour
    {
        [SerializeField] private int _damageValue;

        public void ApplyDamage(GameObject target)
        {
            var healthComponent = target.GetComponent<HealthArmorComponent>();
            if (healthComponent != null)
            {
                healthComponent.ApplyDamage(_damageValue);
            }
        }
    }
}