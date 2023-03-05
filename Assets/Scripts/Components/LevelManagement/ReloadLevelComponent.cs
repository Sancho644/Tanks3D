using Scripts.Components.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Components.LevelManagement
{
    public class ReloadLevelComponent : MonoBehaviour
    {
        public void Reload()
        {
            var session = FindObjectOfType<GameSession>();
            Destroy(session);

            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}