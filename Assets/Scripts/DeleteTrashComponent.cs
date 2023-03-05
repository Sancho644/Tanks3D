using UnityEngine;

namespace Scripts
{
    public class DeleteTrashComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _object;
        private  void Start()
        {
            if(_object != null)
            {
                Destroy(_object, 5f);
            }
        }
    }
}