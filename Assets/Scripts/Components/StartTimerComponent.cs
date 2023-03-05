using UnityEngine;

namespace Scripts.Components
{
    public class StartTimerComponent : MonoBehaviour
    {
        public void StartTimer(GameObject go)
        {
            var timer = go.GetComponent<TimerComponent>();
            if (timer != null)
            {
                timer.StartTimer();
            }
        }
    }
}