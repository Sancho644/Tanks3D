namespace Scripts.Components
{
    using Scripts.Components.HealthArmor;
    using Scripts.Components.LevelManagement;
    using UnityEngine;

    public class FlagController : MonoBehaviour
    {
        [SerializeField] private HealthArmorComponent _healthArmor = default;
        [SerializeField] private ReloadLevelComponent _reload = default;

        private void Start()
        {
            _healthArmor.OnDie += OnFlagDie;
        }

        private void OnFlagDie()
        {
            _reload.Reload();
        }

        private void OnDestroy()
        {
            _healthArmor.OnDie -= OnFlagDie;
        }
    }
}