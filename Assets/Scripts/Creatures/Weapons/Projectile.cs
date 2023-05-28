using Scripts.Components.ColliderBased;
using Scripts.Components.HealthArmor;
using UnityEngine;

namespace Scripts.Creatures.Weapons
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private float _speed = 0.5f;
        [SerializeField] private EnterCollisionComponent _collision;
        [SerializeField] private ModifyHealthArmor _modify;
        [SerializeField] private bool _isEnemyBullet = false;

        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();

            _collision.OnAction += OnCollisionAction;

            if (_rigidbody != null)
            {
                _rigidbody.AddForce(_prefab.transform.forward * _speed, ForceMode.Impulse);
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