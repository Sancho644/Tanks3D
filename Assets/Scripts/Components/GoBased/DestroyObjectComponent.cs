namespace Scripts.Components.GoBased
{
    using UnityEngine;

    public class DestroyObjectComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToDestroy = default;

        public void DestroyObject()
        {
            Destroy(_objectToDestroy);
        }
    }
}