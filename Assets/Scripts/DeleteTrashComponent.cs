namespace Scripts
{
    using UnityEngine;

    public class DeleteTrashComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _object = default;

        private  void Start()
        {
            if(_object != null)
            {
                Destroy(_object, 5f);
            }
        }
    }
}