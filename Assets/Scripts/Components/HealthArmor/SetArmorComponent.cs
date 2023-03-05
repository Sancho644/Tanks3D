using UnityEngine;

namespace Scripts.Components.HealthArmor
{
    public class SetArmorComponent : MonoBehaviour
    {
        [SerializeField] private int _armor;

        public void ApplyArmor(GameObject target)
        {
            var healthComponent = target.GetComponent<HealthArmorComponent>();
            if (healthComponent != null)
            {
                healthComponent.ApplyArmor(_armor);
            }
        }
    }
}