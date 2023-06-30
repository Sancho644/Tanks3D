using Model;
using Model.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Components.LevelManagement
{
    public class ReloadLevelComponent : MonoBehaviour
    {
        public void Reload()
        {
            var session = GameSession.Instance;
            var scene = SceneManager.GetActiveScene();

            SceneManager.LoadScene(scene.name);
            session.LoadLastSave();

            CountOfEnemies.SetCount(0);
        }
    }
}