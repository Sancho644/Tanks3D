namespace Scripts.Creatures.Mobs
{
    using UnityEngine;
    using Scripts.Components;
    using Scripts.Components.GoBased;
    using Scripts.Components.HealthArmor;

    public class BaseCreature : MonoBehaviour
    {
        [SerializeField] private float _speed = 30f;
        [SerializeField] private float _rotationSpeed = 20f;

        [SerializeField] protected Cooldown _attackCooldown = default;
        [SerializeField] protected HealthArmorComponent _healthArmor = default;
        [SerializeField] protected SpawnComponent _attack = default;

        public float _vertical = 0f;
        protected float _horizontal = 0f;
        protected Rigidbody _rigidbody = default;
        protected PlaySoundsComponent _sounds = default;

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

        protected virtual void OnTakeHealthDamage()
        {
            _sounds.Play("HitDamage");
            Debug.Log("-1 HP");
        }
    }
}
