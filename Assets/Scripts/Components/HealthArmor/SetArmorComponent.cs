namespace Scripts.Components.HealthArmor
{
    using UnityEngine;

    public class SetArmorComponent : MonoBehaviour
    {
        [SerializeField] private int _armor = 0;

        public void ApplyArmor(GameObject target)
        {
            if (target.TryGetComponent<HealthArmorComponent>(out HealthArmorComponent healthArmor))
            {
                healthArmor.ApplyArmor(_armor);
            }
        }
    }
}