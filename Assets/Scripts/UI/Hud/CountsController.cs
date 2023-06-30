using Model;
using Model.Data;
using UnityEngine;
using UnityEngine.UI;
using Utils.Disposables;

namespace UI.Hud
{
    public class CountsController : MonoBehaviour
    {
        [SerializeField] private Text _health;
        [SerializeField] private Text _armor;
        [SerializeField] private Text _enemies;
        [SerializeField] private Text _playerScore;

        private readonly CompositeDisposable _trash = new CompositeDisposable();
        private GameSession _session;

        private void Start()
        {
            _session = GameSession.Instance;
            OnCountOfEnemiesChanged();

            _enemies.text = CountOfEnemies.TotalEnemies.ToString();
            CountOfEnemies.OnModify += OnCountOfEnemiesChanged;

            _trash.Retain(_session.Data.PlayerScore.SubscribeAndInvoke(OnPlayerScoreController));
            _trash.Retain(_session.Data.Health.SubscribeAndInvoke(OnHealthChanged));
            _trash.Retain(_session.Data.Armor.SubscribeAndInvoke(OnArmorChanged));
        }

        private void OnPlayerScoreController(int newValue, int oldValue)
        {
            _playerScore.text = _session.Data.PlayerScore.Value.ToString();
        }

        private void OnHealthChanged(int newValue, int oldValue)
        {
            _health.text = _session.Data.Health.Value.ToString();
        }

        private void OnArmorChanged(int newValue, int oldValue)
        {
            _armor.text = _session.Data.Armor.Value.ToString();
        }

        private void OnCountOfEnemiesChanged()
        {
            _enemies.text = CountOfEnemies.TotalEnemies.ToString();
        }

        private void OnDestroy()
        {
            CountOfEnemies.OnModify -= OnCountOfEnemiesChanged;
            _trash.Dispose();
        }
    }
}