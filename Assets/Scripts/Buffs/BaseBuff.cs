using Components.Audio;
using Components.ColliderBased;
using Components.GoBased;
using Model;
using UI;
using UI.Hud;
using UnityEngine;

namespace Buffs
{
    public class BaseBuff : MonoBehaviour
    {
        [SerializeField] private EnterTriggerComponent _trigger;
        [SerializeField] private int _scoreValue;
        [SerializeField] private SpawnComponent _spawnPoints;
        [SerializeField] private GameObject _pointsPrefab;
        
        private PlaySoundsComponent _sounds;
        private GameSession _session;

        private void Start()
        {
            _trigger.OnEnterTriggered += OnTriggered;
            _sounds = GetComponent<PlaySoundsComponent>();
            _session = GameSession.Instance;
            
            if (_pointsPrefab.TryGetComponent<Points>(out Points points))
            {
                points.SetPoints(_scoreValue);
            }
            _spawnPoints.SetSpawnPrefab(_pointsPrefab);
        }

        protected virtual void OnTriggered(GameObject go)
        {
            PlayerScoreController.ModifyScore(_scoreValue);
            _session.Data.PlayerScore.Value = PlayerScoreController.Score;
            _sounds.Play("Up");
            _spawnPoints.SpawnWithoutRotation();

            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _trigger.OnEnterTriggered -= OnTriggered;
        }
    }
}