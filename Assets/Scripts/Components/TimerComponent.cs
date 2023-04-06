namespace Scripts.Components
{
    using UnityEngine;
    using UnityEngine.Events;

    //NOTE: удалить
    public class TimerComponent : MonoBehaviour
    {
        [SerializeField] private float _timer;
        [SerializeField] private bool _startOnAwake;

        [SerializeField] private UnityEvent _onTimerStart;
        [SerializeField] private UnityEvent _onTimerEnd;

        private bool _startFirstEvent = false;
        private bool _startSecondEvent = false;
        private float _reset;

        public void Update()
        {
            if (_startOnAwake)
            {
                _startFirstEvent = true;
                _startSecondEvent = true;
            }

            if (_startFirstEvent)
            {
                _reset = _timer;
                _onTimerStart?.Invoke();
                _startFirstEvent = false;
            }

            if (_startSecondEvent)
            {
                _timer -= Time.deltaTime;
            }

            if (_timer <= 0)
            {
                _onTimerEnd?.Invoke();
                _timer = _reset;
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