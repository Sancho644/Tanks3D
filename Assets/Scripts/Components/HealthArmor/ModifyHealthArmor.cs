namespace Scripts.Components.HealthArmor
{
    using UnityEngine;

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