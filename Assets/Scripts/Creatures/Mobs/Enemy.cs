using Scripts.Components.GoBased;
using Scripts.Model.Data;
using UnityEngine;

namespace Creatures.Mobs
{
    public class Enemy : BaseCreature
    {
        [SerializeField] private SpawnComponent _explosion;

        private void Start()
        {
            _healthArmor.OnDie += OnCreatureDie;
            _healthArmor.OnHpDamage += OnTakeHealthDamage;
            CountOfEnemies.ModifyCount(1);
        }

        private void OnCreatureDie()
        {
            _sounds.Play("Die");
            _explosion.Spawn();
            CountOfEnemies.ModifyCount(-1);

            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _healthArmor.OnDie -= OnCreatureDie;
            _healthArmor.OnHpDamage -= OnTakeHealthDamage;
        }
    }
}