namespace Scripts.Creatures.Player
{
    using UnityEngine;
    using Scripts.Creatures.Mobs;
    using Scripts.Components.Model;
    using Scripts.Components.LevelManagement;
    using Scripts.Components;

    public class Player : BaseCreature
    {
        [SerializeField] private ReloadLevelComponent _reload = default;
        [SerializeField] private Cooldown _buffDamageCooldown = default;

        private GameSession _session = default;
        private bool _damageBuff = false;

        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            _session = GameSession.Instance;

            _healthArmor.SetHealth(_session.Data.Health.Value);

            _healthArmor.OnDie += OnPlayerDie;
            _healthArmor.OnArmorChange += OnTakeArmorDamage;
            _healthArmor.OnHpDamage += OnTakeHealthDamage;
            _healthArmor.OnHpChange += OnHealthChanged;
        }

        private void OnPlayerDie()
        {
            _sounds.Play("Die");
            _reload.Reload();
        }

        public void OnHealthChanged(int currentHealth)
        {
            _session.Data.Health.Value = currentHealth;
        }

        private void Update()
        {
            _vertical = Input.GetAxis("Vertical");
            _horizontal = Input.GetAxis("Horizontal");

            if (_damageBuff && _buffDamageCooldown.IsReady)
            {
                DisableDamageBuff();
            }

            if (Input.GetButtonDown("FireProjectilePlayerOne"))
            {
                Fire();
            }
        }

        public override void Fire()
        {
            if (_damageBuff && _attackCooldown.IsReady)
            {
                _attackCooldown.Reset();
                _attack.AlternativeSpawn();
                _sounds.Play("Fire");
            }
            else if(_buffDamageCooldown.IsReady)
            {
                base.Fire();
            }
        }

        public void EnableDamageBuff()
        {
            _damageBuff = true;
            _buffDamageCooldown.Reset();
        }

        private void DisableDamageBuff()
        {
            _damageBuff = false;
        }

        protected override void OnTakeHealthDamage()
        {
            base.OnTakeHealthDamage();
        }

        private void OnTakeArmorDamage(int currentArmor)
        {
            _session.Data.Armor.Value = currentArmor;
        }

        private void OnDestroy()
        {
            _healthArmor.OnDie -= OnPlayerDie;
            _healthArmor.OnArmorChange -= OnTakeArmorDamage;
            _healthArmor.OnHpDamage -= OnTakeHealthDamage;
            _healthArmor.OnHpChange -= OnHealthChanged;
        }
    }
}