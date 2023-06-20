using System.Collections;
using Components;
using Components.GoBased;
using Creatures.Mobs;
using Model;
using UnityEngine;
using Utils;

namespace Creatures.Player
{
    public class Player : BaseCreature
    {
        [SerializeField] private float _deathWindowCooldown;
        [SerializeField] private Cooldown _buffDamageCooldown;
        [SerializeField] private SpawnComponent _explosion;
        [SerializeField] private GameObject _tankModel;

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
            _explosion.Spawn();
            _tankModel.gameObject.SetActive(false);

            StartCoroutine(DeathWindow());
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

        private IEnumerator DeathWindow()
        {
            yield return new WaitForSeconds(_deathWindowCooldown);
            
            WindowUtils.CreateWindow("UI/PlayerDeathWindow");
            Destroy(gameObject);

            yield return null;
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