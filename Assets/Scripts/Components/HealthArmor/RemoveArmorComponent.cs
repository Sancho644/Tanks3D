namespace Scripts.Components.HealthArmor
{
    using UnityEngine;

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