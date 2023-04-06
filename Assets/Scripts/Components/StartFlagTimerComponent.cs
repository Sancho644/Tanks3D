namespace Scripts.Components
{
    using UnityEngine;
    
    //NOTE: переделать.
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