using UnityEngine;

namespace Scripts
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] protected float _speed;

        protected Rigidbody Rigidbody;

        private void Start()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Rigidbody.AddForce(_prefab.transform.forward * _speed, ForceMode.Impulse);
        }
    }
}