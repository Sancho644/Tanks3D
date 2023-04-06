namespace Scripts.Components.LevelManagement
{
    using Scripts.Components.Model;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class ReloadLevelComponent : MonoBehaviour
    {
        public void Reload()
        {
            var session = GameSession.Instance;
            session.LoadLastSave();

            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);            
        }
    }
}