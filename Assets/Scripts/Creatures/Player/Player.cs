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
        private bool _check = false;

        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            _session = GameSession.Instance;

            _healthArmor.SetHealth(_session.Data.Hp);

            _healthArmor.OnDie += OnPlayerDie;
            _healthArmor.OnArmorDamage += OnTakeArmorDamage;
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
            _session.Data.Hp = currentHealth;
        }

        private void Update()
        {
            _vertical = Input.GetAxis("Vertical");
            _horizontal = Input.GetAxis("Horizontal");

            if (_check)
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
            if (_damageBuff)
            {
                if (_attackCooldown.IsReady)
                {
                    _attackCooldown.Reset();
                    _attack.AlternativeSpawn();
                    _sounds.Play("Fire");
                }
            }
            else
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
            if (_buffDamageCooldown.IsReady)
            {
                _damageBuff = false;
            }
        }

        protected override void OnTakeHealthDamage()
        {
            base.OnTakeHealthDamage();
        }

        private void OnTakeArmorDamage(int currentArmor)
        {
            _session.Data.Armor = currentArmor;
        }

        private void OnDestroy()
        {
            _healthArmor.OnDie -= OnPlayerDie;
            _healthArmor.OnArmorDamage -= OnTakeArmorDamage;
            _healthArmor.OnHpDamage -= OnTakeHealthDamage;
        }
    }
}