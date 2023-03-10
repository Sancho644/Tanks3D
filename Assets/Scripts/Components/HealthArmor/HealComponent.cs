using UnityEngine;

namespace Scripts.Components.HealthArmor
{
    public class HealComponent : MonoBehaviour
    {
        [SerializeField] private int _heal;

        public void ApplyHeal(GameObject target)
        {
            var healthComponent = target.GetComponent<HealthArmorComponent>();
            if (healthComponent != null)
            {
                healthComponent.ApplyHeal(_heal);
            }
        }
    }
}