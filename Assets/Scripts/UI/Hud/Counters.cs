namespace Scripts.UI.Hud
{
    using Scripts.Components.Model;
    using Scripts.Utils.Disposables;
    using UnityEngine;
    using UnityEngine.UI;

    public class Counters : MonoBehaviour
    {
        [SerializeField] private Text _health = default;
        [SerializeField] private Text _armor = default;

        private readonly CompositeDisposable _trash = new CompositeDisposable();
        private GameSession _session = default;

        private void Start()
        {
            _session = GameSession.Instance;

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

        private void OnDestroy()
        {
            _trash.Dispose();
        }
    }
}