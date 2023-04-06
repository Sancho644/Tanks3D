namespace Scripts.Components.LevelManagement
{
    using Scripts.Components.Model;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class ExitLevelComponent : MonoBehaviour
    {
        [SerializeField] private string _sceneName = default;

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

        [ContextMenu("Exit")]
        public void Exit()
        {
            var session = GameSession.Instance;
            session.Save();

            SceneManager.LoadScene(_sceneName);
        }
    }
}