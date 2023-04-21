namespace Scripts
{
    using UnityEngine;

    public class DeleteTrashComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _object = default;
        [SerializeField] private float _cooldownTime = 5f;

        private  void Start()
        {
            if(_object != null)
            {
                Destroy(_object, _cooldownTime);
            }
        }
    }
}