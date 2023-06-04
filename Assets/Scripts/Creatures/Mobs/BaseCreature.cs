using Components.HealthArmor;
using Scripts.Components;
using Scripts.Components.Audio;
using Scripts.Components.GoBased;
using Scripts.Components.HealthArmor;
using UnityEngine;

namespace Creatures.Mobs
{
    public class BaseCreature : MonoBehaviour
    {
        [SerializeField] private float _speed = 30f;
        [SerializeField] private float _rotationSpeed = 20f;

        [SerializeField] protected Cooldown _attackCooldown;
        [SerializeField] protected HealthArmorComponent _healthArmor;
        [SerializeField] protected SpawnComponent _attack;

        protected float _horizontal = 0f;
        protected float _vertical = 0f;
        protected PlaySoundsComponent _sounds;
        
        private Rigidbody _rigidbody;

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
            _rigidbody.AddForce(vertical * _speed * Time.deltaTime * transform.forward);
        }

        public void HorizontalMovement(float horizontal)
        {
            _rigidbody.transform.Rotate(0, horizontal * Time.deltaTime * _rotationSpeed, 0);
        }

        public virtual void Fire()
        {
            if (_attackCooldown.IsReady)
            {
                _attack.Spawn();
                _attackCooldown.Reset();
                _sounds.Play("Fire");
            }
        }

        protected void OnTakeHealthDamage()
        {
            _sounds.Play("HitDamage");
        }
    }
}
