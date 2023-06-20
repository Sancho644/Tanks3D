using UnityEngine;

namespace Components.HealthArmor
{
    public class RemoveArmorComponent : MonoBehaviour
    {
        [SerializeField] private int _usualArmor = 0;

        public void DisableArmorBuff(GameObject target)
        {
            if (target.TryGetComponent<HealthArmorComponent>(out HealthArmorComponent healthArmor))
            {
                healthArmor.DisableArmorBuff(_usualArmor);
            }
        }
    }
}