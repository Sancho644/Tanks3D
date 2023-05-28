using Creatures.Mobs;
using Scripts.Components;
using Scripts.Components.LevelManagement;
using Scripts.Model;
using UnityEngine;

namespace Creatures.Player
{
    public class Player : BaseCreature
    {
        [SerializeField] private ReloadLevelComponent _reload;
        [SerializeField] private Cooldown _buffDamageCooldown;

        private GameSession _session;
        private bool _damageBuff;

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

        private void OnHealthChanged(int currentHealth)
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