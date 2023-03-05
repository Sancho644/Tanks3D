using Scripts.Utils;
using UnityEngine;

namespace Scripts.UI.Hud
{
    public class HudController : MonoBehaviour
    {
        //[SerializeField] private ProgressBarWidget _healthBar;

        //private GameSession _session;
        //private CompositeDisposable _trash = new CompositeDisposable();

        private void Start()
        {
            //_session = FindObjectOfType<GameSession>();
        }

        public void OnSettings()
        {
            WindowUtils.CreateWindow("UI/InGameMenuWindow");
        }
    }
}