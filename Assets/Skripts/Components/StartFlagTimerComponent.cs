using UnityEngine;

namespace Skripts.Components
{
    public class StartFlagTimerComponent : MonoBehaviour
    {
        public void StartTimer()
        {
            var wall = GameObject.Find("TimedIronWall");

            if (wall != null)
            {
                var timer = wall.GetComponent<TimerComponent>();
                timer.StartTimer();
            }
        }
    }
}