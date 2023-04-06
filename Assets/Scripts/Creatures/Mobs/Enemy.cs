namespace Scripts.Creatures.Mobs
{
    using Scripts.Components.GoBased;
    using UnityEngine;

    public class Enemy : BaseCreature
    {
        [SerializeField] private SpawnComponent _explosion = default;

        private void Start()
        {
            _healthArmor.OnDie += OnCreatureDie;
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
        }
    }
}