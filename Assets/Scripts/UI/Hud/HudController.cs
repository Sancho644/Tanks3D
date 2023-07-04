using Model;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI.Hud
{
    public class HudController : MonoBehaviour
    {
        [SerializeField] private Text _starLevelText;

        private GameSession _session;

        private void Start()
        {
            _session = GameSession.Instance;

            _starLevelText.text = _session.Data.CurrentLevel.Value;
        }

        public void OnSettings()
        {
            WindowUtils.CreateWindow("UI/Windows/InGameMenuWindow");
        }
    }
}