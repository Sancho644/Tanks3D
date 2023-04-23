using UnityEngine;

namespace Scripts.Components.HealthArmor
{
    public class RemoveArmorComponent : MonoBehaviour
    {
        [SerializeField] private int _usualArmor = 0;

        public void DisabbleArmorBuff(GameObject target)
        {
            if (target.TryGetComponent<HealthArmorComponent>(out HealthArmorComponent healthArmor))
            {
                healthArmor.DisabbleArmorBuff(_usualArmor);
            }
        }
    }
}