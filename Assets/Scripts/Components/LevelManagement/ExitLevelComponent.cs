using Model;
using UI.LevelsLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Components.LevelManagement
{
    public class ExitLevelComponent : MonoBehaviour
    {
        [SerializeField] private string _nextSceneName;

        private GameSession _session;
        
        public static ExitLevelComponent Instance { get; private set; }

        private void Awake()
        {
            _session = GameSession.Instance;
            var scene = SceneManager.GetActiveScene();
            _session.Data.CurrentLevel.Value = scene.name;
            
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void Exit()
        {
            _session.Save();
            
            var loader = FindObjectOfType<LevelLoader>();
            loader.LoadLevel(_nextSceneName);
        }
    }
}