using UnityEngine;

namespace Skripts.Components
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
