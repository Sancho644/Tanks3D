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

        private Action _closeAction;
        
        protected override void Start()
        {
            base.Start();
            
            if (_session.PlayerData.Data.PlayerScore.Value != 0 && _session.PlayerData.Data.CurrentLevel.Value != null)
            {
                _continueButton.gameObject.SetActive(true);
            }
        }

        public void OnShowSettings()
        {
            WindowUtils.CreateWindow("UI/SettingsWindow");
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