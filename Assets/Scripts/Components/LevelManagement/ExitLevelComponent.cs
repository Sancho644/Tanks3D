using Scripts.Model;
using UI.LevelsLoader;
using UnityEngine;

namespace Components.LevelManagement
{
    public class ExitLevelComponent : MonoBehaviour
    {
        [SerializeField] private string _nextSceneName;
        [SerializeField] private string _currentSceneName;
        
        public string CurrentSceneName => _currentSceneName;

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
            var loader = FindObjectOfType<LevelLoader>();
            loader.LoadLevel(_nextSceneName);
        }
    }
}