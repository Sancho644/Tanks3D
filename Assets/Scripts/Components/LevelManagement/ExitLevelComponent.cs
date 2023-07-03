using System.Collections;
using Model;
using Model.Data;
using UI.LevelsLoader;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Components.LevelManagement
{
    public class ExitLevelComponent : MonoBehaviour
    {
        [SerializeField] private string _nextSceneName;
        [SerializeField] private float _nextLevelCooldown;
        [SerializeField] private UnityEvent _onNextLevel;

        private GameSession _session;

        private void Awake()
        {
            var scene = SceneManager.GetActiveScene();

            CountOfEnemies.OnEnemyEnds += OnModifyCountOfEnemies;
            _session = GameSession.Instance;
            _session.Data.CurrentLevel.Value = scene.name;
        }

        private void OnModifyCountOfEnemies()
        {
            Exit();
        }

        private void Exit()
        {
            _session.SaveProgress();
            _onNextLevel?.Invoke();

            StartCoroutine(StartNextLevel());
        }

        private IEnumerator StartNextLevel()
        {
            yield return new WaitForSeconds(_nextLevelCooldown);

            var loader = FindObjectOfType<LevelLoader>();
            loader.LoadLevel(_nextSceneName);
        }

        private void OnDestroy()
        {
            CountOfEnemies.OnEnemyEnds -= OnModifyCountOfEnemies;
        }
    }
}