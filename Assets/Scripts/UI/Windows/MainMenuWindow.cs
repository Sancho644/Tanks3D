using System;
using Model.Data;
using Model.Data.Properties;
using UI.LevelsLoader;
using UnityEngine;
using Utils;

namespace UI.Windows
{
    public class MainMenuWindow : AnimatedWindow
    {
        [SerializeField] private GameObject _continueButton;

        private const string SettingsWindowPath = "UI/SettingsWindow";
        private const string LevelOne = "Level 1";
        private Action _closeAction;
        
        protected override void Start()
        {
            base.Start();
            var sessionData = _session.PlayerData.Data;
            
            if (sessionData.PlayerScore.Value != 0 && sessionData.CurrentLevel.Value != null && sessionData.Health.Value != 0)
            {
                _continueButton.gameObject.SetActive(true);
            }
        }

        public void OnShowSettings()
        {
            WindowUtils.CreateWindow(SettingsWindowPath);
        }

        public void OnContinue()
        {
            _closeAction = () =>
            {
                CountOfEnemies.SetCount(0);
                
                var loader = FindObjectOfType<LevelLoader>();
                loader.LoadLevel(_session.Data.CurrentLevel.Value);
            };
            
            Close();
        }

        public void OnStartGame()
        {
            _closeAction = () =>
            {
                _continueButton.gameObject.SetActive(false);
                CountOfEnemies.SetCount(0);

                var data = new PlayerData
                {
                    Health = new IntProperty
                    {
                        Value = 3
                    }
                };
                
                _session.SetPlayerData(data);
                _session.SaveProgress();

                var loader = FindObjectOfType<LevelLoader>();
                loader.LoadLevel(LevelOne);
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