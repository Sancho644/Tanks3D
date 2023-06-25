using Components.Audio;
using Components.ColliderBased;
using Model;
using UI.Hud;
using UnityEngine;

namespace Buffs
{
    public class BaseBuff : MonoBehaviour
    {
        [SerializeField] private EnterTriggerComponent _trigger;
        [SerializeField] private int _scoreValue;
        
        private PlaySoundsComponent _sounds;
        private GameSession _session;

        private void Start()
        {
            _trigger.OnEnterTriggered += OnTriggered;
            _sounds = GetComponent<PlaySoundsComponent>();
            _session = GameSession.Instance;
        }

        protected virtual void OnTriggered(GameObject go)
        {
            PlayerScoreController.ModifyScore(_scoreValue);
            _session.Data.PlayerScore.Value = PlayerScoreController.Score;
            _sounds.Play("Up");
            
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _trigger.OnEnterTriggered -= OnTriggered;
        }
    }
}