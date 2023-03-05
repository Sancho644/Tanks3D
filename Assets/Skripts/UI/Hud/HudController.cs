using Skripts.Utils;
using Skripts.Utils.Disposables;
using UnityEngine;

namespace Skripts.UI.Hud
{
    public class HudController : MonoBehaviour
    {
        //[SerializeField] private ProgressBarWidget _healthBar;

        private GameSession _session;
        private CompositeDisposable _trash = new CompositeDisposable();

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
        }

        public void OnSettings()
        {
            WindowUtils.CreateWindow("UI/InGameMenuWindow");
        }
    }
}