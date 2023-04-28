using Scripts.Model.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Model
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private PlayerData _data;

        private const string HUD = "Hud";
        private PlayerData _save;

        public PlayerData Data => _data;
        public static GameSession Instance { get; private set; }

        private void Awake()
        {
            LoadHud();

            if (IsSessionExit())
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                Save();
                DontDestroyOnLoad(this);
                Instance = this;
            }
        }

        private void LoadHud()
        {
            SceneManager.LoadScene(HUD, LoadSceneMode.Additive);
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

        public void Save()
        {
            _save = _data.Clone();
        }

        public void LoadLastSave()
        {
            _data = _save.Clone();
        }

        private void OnDestroy()
        {
            if (Instance == null)
                Instance = null;
        }
    }
}