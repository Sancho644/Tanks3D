using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Windows
{
    public class PlayerDeathWindow : AnimatedWindow
    {
        private float _defaultTimeScale;

        protected override void Start()
        {
            base.Start();

            _defaultTimeScale = Time.timeScale;
            Time.timeScale = 0;
        }

        public void OnExit()
        {
            SceneManager.LoadScene("MainMenu");

            Destroy(_session.gameObject);
        }

        private void OnDestroy()
        {
            Time.timeScale = _defaultTimeScale;
        }
    }
}