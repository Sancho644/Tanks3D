using Components.GoBased;
using Model;
using Model.Data;
using UI;
using UI.Hud;
using UnityEngine;

namespace Creatures.Mobs
{
    public class Enemy : BaseCreature
    {
        [SerializeField] private SpawnComponent _explosion;
        [SerializeField] private SpawnComponent _spawnPoints;
        [SerializeField] private GameObject _pointsPrefab;
        [SerializeField] private int _scoreValue;

        private GameSession _session;

        private void Start()
        {
            _healthArmor.OnDie += OnCreatureDie;
            _healthArmor.OnHpDamage += OnTakeHealthDamage;
            _session = GameSession.Instance;
            
            if (_pointsPrefab.TryGetComponent<Points>(out Points points))
            {
                points.SetPoints(_scoreValue);
            }
            _spawnPoints.SetSpawnPrefab(_pointsPrefab);

            CountOfEnemies.ModifyCount(1);
        }

        private void OnCreatureDie()
        {
            _sounds.Play("Die");
            _explosion.Spawn();
            _spawnPoints.SpawnWithoutRotation();
            
            PlayerScoreController.ModifyScore(_scoreValue);
            _session.Data.PlayerScore.Value = PlayerScoreController.Score;
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