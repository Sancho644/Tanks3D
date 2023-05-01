using Scripts.Model;
using Scripts.UI.LevelsLoader;
using UnityEngine;

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
            var loader = FindObjectOfType<LevelLoader>();
            loader.LoadLevel(_sceneName);
        }
    }
}