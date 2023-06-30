using System;
using Model.Data;
using Model.Data.Properties;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Windows
{
    public class FinalMenuWindow : AnimatedWindow
    {
        private const string MainMenu = "MainMenu";

        private Action _closeAction;

        public void OnMainMenu()
        {
            var data = new PlayerData
            {
                Health = new IntProperty
                {
                    Value = 3
                }
            };

            _session.SetPlayerData(data);
            _session.SaveProgress();

            SceneManager.LoadScene(MainMenu);
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