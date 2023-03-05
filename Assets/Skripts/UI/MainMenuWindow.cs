using Skripts.Utils;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Skripts.UI
{
    public class MainMenuWindow : AnimatedWindow
    {
        private Action _closeAction;

        public void OnShowSettings()
        {
            WindowUtils.CreateWindow("UI/SettingsWindow");
        }

        public void OnStartGame()
        {
            SceneManager.LoadScene("Level 1");
           /* _closeAction = () =>
            {
                var loader = FindObjectOfType<LevelLoader>();
                loader.LoadLevel("Level 1");
            };
            Close();*/
        }

        public void OnExit()
        {
            _closeAction = () =>
            {

                Application.Quit();

#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            };

            Close();
        }

        public override void OnCloseAnimationComplete()
        {
            _closeAction?.Invoke();

            base.OnCloseAnimationComplete();
        }
    }
}