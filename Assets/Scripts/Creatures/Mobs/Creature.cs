using UnityEngine;
using Scripts.Components;
using Scripts.Components.GoBased;

namespace Scripts.Creatures.Mobs
{
    public class Creature : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationspeed;

        [SerializeField] private GameObject _spawnProjectilePosition;

        [SerializeField] private Cooldown _attackCooldown;
        [SerializeField] protected SpawnComponent _attack;

        protected float _vertical;
        protected float _horizontal;
        protected Rigidbody _rigidbody;
        protected PlaySoundsComponent _sounds;

        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _sounds = GetComponent<PlaySoundsComponent>();
        }

        private void FixedUpdate()
        {
            VerticalMovement(_vertical);
            HorizontalMovement(_horizontal);
        }

        public void VerticalMovement(float vertical)
        {
            _rigidbody.AddForce(vertical * _speed * Time.deltaTime * transform.forward );
        }

        public void HorizontalMovement(float horizontal)
        {
            _rigidbody.transform.Rotate(0, horizontal * _rotationspeed * Time.deltaTime, 0);
        }

        public virtual void Fire()
        {
            if (_attackCooldown.IsReady)
            {
                _attack.SpawnPrefab();
                _attackCooldown.Reset();
                _sounds.Play("Fire");
            }
        }

        protected virtual void TakeHPDamage()
        {
            _sounds.Play("HitDamage");
            Debug.Log("-1 HP");
        }

        protected virtual void TakeArmorDamage()
        {
            Debug.Log("-1 Armor");
        }

        public void OnDie()
        {
            _sounds.Play("Die");
        }
    }
}
