using System;
using UI.LevelsLoader;
using UnityEngine;
using Utils;

namespace UI.Windows
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
            _closeAction = () =>
            {
                var loader = FindObjectOfType<LevelLoader>();
                loader.LoadLevel("Level 1");
            };

            Close();
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

        protected override void OnCloseAnimationComplete()
        {
            _closeAction?.Invoke();

            base.OnCloseAnimationComplete();
        }
    }
}