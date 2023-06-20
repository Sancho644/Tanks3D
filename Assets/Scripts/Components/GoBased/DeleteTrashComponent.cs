using UnityEngine;

namespace Components.GoBased
{
    public class DeleteTrashComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _object;
        [SerializeField] private float _cooldownTime = 5f;

        private void Start()
        {
            if(_object != null)
                Destroy(_object, _cooldownTime);
        }
    }
}