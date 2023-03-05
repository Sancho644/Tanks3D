using UnityEngine;
using UnityEngine.Events;

namespace Skripts.Components
{
    public class FlagTimerComponent : MonoBehaviour
    {
        [SerializeField] private float _Timer;
        [SerializeField] private UnityEvent _onTimerStart;
        [SerializeField] private UnityEvent _onTimerEnd;

        private bool _startFirstEvent = false;
        private bool _startSecondEvent = false;


        public void Update()
        {
            if (_startFirstEvent)
            {
                _onTimerStart?.Invoke();
                _startFirstEvent = false;
            }

            if (_startSecondEvent)
            {
                _Timer -= Time.deltaTime;
            }

            if (_Timer <= 0)
            {
                _onTimerEnd?.Invoke();
                _Timer = 5f;
                _startSecondEvent = false;
            }

        }

        public void StartTimer()
        {
            _startFirstEvent = true;
            _startSecondEvent = true;
        }
    }
}
