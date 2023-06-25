using Model.Data;
using UI.Hud;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Model
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private PlayerData _data;

        private const string HUD = "Hud";
        private const string MainMenu = "MainMenu";
        private PlayerData _save;
        
        private SaveSystem<PlayerData> _systemData;
        private SaveData<PlayerData> _playerData = new SaveData<PlayerData>();

        public SaveData<PlayerData> PlayerData => _playerData;
        public PlayerData Data => _data;
        public static GameSession Instance { get; private set; }

        private void Awake()
        {
            _systemData = new SaveSystem<PlayerData>();
            
            if (SceneManager.GetActiveScene().name != MainMenu)
            {
                LoadHud();
            }

            if (IsSessionExit())
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                Save();
                Init();
                DontDestroyOnLoad(this);
                Instance = this;
            }
        }

        private void LoadHud()
        {
            SceneManager.LoadScene(HUD, LoadSceneMode.Additive);
        }

        public void SetPlayerData(PlayerData data)
        {
            _data = data;
            _save = _data.Clone();
            PlayerScoreController.SetScore(_data.PlayerScore.Value);

            SavePlayerData();
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

        private void Init()
        {
            _data = _playerData.Data;
            _save = _data.Clone();
            PlayerScoreController.SetScore(_data.PlayerScore.Value);
        }

        public void Save()
        {
            _playerData = _systemData.Load();
        }

        public void LoadLastSave()
        {
            _data = _save.Clone();
            PlayerScoreController.SetScore(_data.PlayerScore.Value);
        }
        
        private void SavePlayerData()
        {
            _playerData.Data = _data;
            _systemData.Save(_playerData);
        }
        
        [ContextMenu("ClearSave")]
        public void ClearSave()
        {
            _systemData.ClearSave();
        }

        private void OnDestroy()
        {
            SavePlayerData();
            
            if (Instance == null)
                Instance = null;
        }
    }
}