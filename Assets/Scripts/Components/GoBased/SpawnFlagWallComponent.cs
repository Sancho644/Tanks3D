using UnityEngine;

namespace Scripts.Components.GoBased
{
    public class SpawnFlagWallComponent : MonoBehaviour
    {
        public void Spawn(GameObject target)
        {
            var spawnComponent = target.GetComponent<ActiveObjectComponent>();
            if (spawnComponent != null)
            {
                spawnComponent.SetActiveObject();
            }
        }
    }
}