using Components.LevelManagement;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI.Hud
{
    public class HudController : MonoBehaviour
    {
        [SerializeField] private Text _starLevelText;

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