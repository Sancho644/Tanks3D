using Model;
using Model.Data;
using UnityEngine;
using UnityEngine.UI;
using Utils.Disposables;

namespace UI.Hud
{
    public class Counters : MonoBehaviour
    {
        [SerializeField] private Text _health;
        [SerializeField] private Text _armor;
        [SerializeField] private Text _enemies;

        private readonly CompositeDisposable _trash = new CompositeDisposable();
        private GameSession _session;

        private void Start()
        {
            _session = GameSession.Instance;
            OnCountOfEnemiesChanged();

            _enemies.text = CountOfEnemies.TotalEnemies.ToString();
            CountOfEnemies.OnModify += OnCountOfEnemiesChanged;

            _trash.Retain(_session.Data.Health.SubscribeAndInvoke(OnHealthChanged));
            _trash.Retain(_session.Data.Armor.SubscribeAndInvoke(OnArmorChanged));
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