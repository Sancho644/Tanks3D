using UnityEngine;
using Skripts.Creatures.Mobs;
using Skripts.Components;

namespace Skripts.Creatures.Player
{
    public class Player : Creature
    {
        private GameSession _session;
        private bool _checkDamageBuff;

        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
            var health = GetComponent<HealthArmorComponent>();

            health.SetHealth(_session.Data.Hp);
        }

        public void OnHealthChanged(int currentHealth)
        {
            _session.Data.Hp = currentHealth;
        }

        private void Update()
        {
            _vertical = Input.GetAxis("Vertical");
            _horizontal = Input.GetAxis("Horizontal");

            Fire();
        }

        public override void Fire()
        {
            if (Input.GetButtonDown("FireProjectilePlayerOne"))
            {
                if (_checkDamageBuff)
                {
                    _attack.SpawnAlternativePrefab();
                    _sounds.Play("Fire");
                }
                else
                {
                    base.Fire();
                }
            }
        }

        public void EnableDamageBuff()
        {
            _checkDamageBuff = true;
        }
        
        public void DisableDamageBuff()
        {
            _checkDamageBuff = false;
        }

        protected override void TakeHPDamage()
        {
            base.TakeHPDamage();
            _sounds.Play("HitDamege");
        }

        protected override void TakeArmorDamage()
        {
            base.TakeArmorDamage();
        }
    }
}
