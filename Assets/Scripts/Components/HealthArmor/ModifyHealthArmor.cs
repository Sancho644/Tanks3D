using Components.HealthArmor;
using UnityEngine;

namespace Scripts.Components.HealthArmor
{
    public class ModifyHealthArmor : MonoBehaviour
    {
        [SerializeField] private int _healthDelta = 1;

        public void Apply(GameObject target)
        {
            if (target.TryGetComponent<HealthArmorComponent>(out HealthArmorComponent healthArmor))
            {
                healthArmor.ModifyHealth(_healthDelta);
            }
        }
    }
}