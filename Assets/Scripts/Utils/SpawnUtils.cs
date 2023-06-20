using UnityEngine;

namespace Utils
{
    public class SpawnUtils : MonoBehaviour
    {
        private const string ContainerName = "#####SPAWNER#####";

        public static GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            var container = GameObject.Find(ContainerName);
            
            if (container == null)
                container = new GameObject(ContainerName);

            return Object.Instantiate(prefab, position, rotation, container.transform);
        }
    }
}