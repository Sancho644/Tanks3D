using Scripts.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Components.LevelManagement
{
    public class ExitLevelComponent : MonoBehaviour
    {
        [SerializeField] private string _sceneName;

        public static ExitLevelComponent Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                return;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void Exit()
        {
            var session = GameSession.Instance;
            session.Save();

            SceneManager.LoadScene(_sceneName);
        }
    }
}