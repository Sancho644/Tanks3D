﻿using Scripts.Model;
using Scripts.UI.Windows;
using Scripts.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace UI.Windows
{
    public class InGameMenuWindow : AnimatedWindow
    {
        private float _defaultTimeScale;

        protected override void Start()
        {
            base.Start();

            _defaultTimeScale = Time.timeScale;
            Time.timeScale = 0;
        }

        public void OnShowSettings()
        {
            WindowUtils.CreateWindow("UI/SettingsWindow");
            Close();
        }

        public void OnExit()
        {
            SceneManager.LoadScene("MainMenu");

            var session = GameSession.Instance;
            Destroy(session.gameObject);
        }

        private void OnDestroy()
        {
            Time.timeScale = _defaultTimeScale;
        }
    }
}