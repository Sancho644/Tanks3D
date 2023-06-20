using Components.HealthArmor;
using Components.LevelManagement;
using UnityEngine;

namespace Components
{
    public class FlagController : MonoBehaviour
    {
        [SerializeField] private HealthArmorComponent _healthArmor;
        [SerializeField] private ReloadLevelComponent _reload;

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