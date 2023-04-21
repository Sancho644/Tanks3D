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
        [SerializeField] private bool _isEnemyBullet = false;

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
            if (tag == "Player" || tag == "Flag")
            {
                AddDamage(go);
            }

            if (tag == "Obstacle" || tag == "Bullet")
            {
                Destroy(gameObject);
            }

            if (tag == "Enemy")
            {
                if (_isEnemyBullet)
                {
                    Destroy(gameObject);

                    return;
                }

                AddDamage(go);
            }
        }

        private void AddDamage(GameObject go)
        {
            _modify.Apply(go);

            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _collision.OnAction -= OnCollisionAction;
        }
    }
}