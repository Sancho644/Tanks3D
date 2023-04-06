namespace Scripts.Creatures.Weapons
{
    using Scripts.Components.ColliderBased;
    using Scripts.Components.HealthArmor;
    using UnityEngine;

    public class Projectile : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab = default;
        [SerializeField] private float _speed = 0.5f;
        [SerializeField] private EnterCollisionComponent _collision = default;
        [SerializeField] private ModifyHealthArmor _modify = default;

        private Rigidbody Rigidbody = default;

        private void Start()
        {
            Rigidbody = GetComponent<Rigidbody>();

            _collision.OnAction += OnCollisionAction;

            if (Rigidbody != null)
            {
                Rigidbody.AddForce(_prefab.transform.forward * _speed, ForceMode.Impulse);
            }
        }

        private void OnCollisionAction(string tag, GameObject go)
        {
            if (tag == "Player" || tag == "Enemy" || tag == "Flag")
            {
                _modify.Apply(go);

                Destroy(gameObject);
            }

            if (tag == "Obstacle" || tag == "Bullet")
            {
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            _collision.OnAction -= OnCollisionAction;
        }
    }
}