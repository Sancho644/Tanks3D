using UnityEngine;

namespace Scripts.Components.HealthArmor
{
    public class RemoveArmorComponent : MonoBehaviour
    {
        [SerializeField] private int _usualArmor;

        public void DisabbleArmorBuff(GameObject target)
        {
            var healthComponent = target.GetComponent<HealthArmorComponent>();
            healthComponent.DisabbleArmorBuff(_usualArmor);
        }
    }
}