using UnityEngine;
using UnityEngine.SceneManagement;

namespace Skripts
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private PlayerData _data;
        public PlayerData Data => _data;

        private void Awake()
        {
            LoadHud();

            if (IsSessionExit())
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                DontDestroyOnLoad(this);
            }
        }

        private void LoadHud()
        {
            SceneManager.LoadScene("Hud", LoadSceneMode.Additive);
        }

        private bool IsSessionExit()
        {
            var session = FindObjectsOfType<GameSession>();
            foreach (var gameSession in session)
            {
                if (gameSession != this)
                    return true;
            }

            return false;
        }
    }
}