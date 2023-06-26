using Model;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace UI.Windows
{
    public class InGameMenuWindow : AnimatedWindow
    {
        private float _defaultTimeScale;
        private const string MainMenu = "MainMenu";
        private const string SettingsWindowPath = "UI/SettingsWindow";

        protected override void Start()
        {
            base.Start();

            _defaultTimeScale = Time.timeScale;
            Time.timeScale = 0;
        }

        public void OnShowSettings()
        {
            WindowUtils.CreateWindow(SettingsWindowPath);
            Close();
        }

        public void OnExit()
        {
            SceneManager.LoadScene(MainMenu);

            var session = GameSession.Instance;
            Destroy(session.gameObject);
        }

        private void OnDestroy()
        {
            Time.timeScale = _defaultTimeScale;
        }
    }
}