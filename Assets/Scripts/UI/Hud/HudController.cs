using Components.LevelManagement;
using Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Hud
{
    public class HudController : MonoBehaviour
    {
        [SerializeField] private Text _starLevelText;
        
        //private GameSession _session;
        //private CompositeDisposable _trash = new CompositeDisposable();

        private void Start()
        {
            var exitLevel = ExitLevelComponent.Instance;
            _starLevelText.text = exitLevel.CurrentSceneName;
        }

        public void OnSettings()
        {
            WindowUtils.CreateWindow("UI/InGameMenuWindow");
        }
    }
}