namespace Scripts.Creatures.Mobs
{
    using Scripts.Components.ColliderBased;
    using Scripts.Components.GoBased;
    using System.Collections;
    using UnityEngine;

    public class Patrol : MonoBehaviour
    {
        [SerializeField] private Checker _obstacleCheck = default;
        [SerializeField] private Enemy _creature = default;
        [SerializeField] private float _direction = 1f;

        private IEnumerator _current = default;
        private bool _isTurning = false;

        public IEnumerator DoPatrol()
        {
            while (!_obstacleCheck.IsTochingLayer && !_isTurning)
            {
                _creature.Fire();

                if (_obstacleCheck.IsTochingLayer)
                {
                    break;
                }
                else
                {
                    _creature.VerticalMovement(_direction);
                }

                yield return null;
            }

            StartState(RandomRotate());
        }

        public void TryStop()
        {
            _creature.VerticalMovement(0f);
            _creature.HorizontalMovement(0f);

            if (_current != null)
                StopCoroutine(_current);
            _current = null;
        }

        private IEnumerator RandomRotate()
        {
            _isTurning = true;
            var randomTime = Random.Range(0.1f, 1.5f);
            var time = Time.time + randomTime;
            float randValue = RandomNumbers.RandomWithTwoNumber(-1f, 1f);

            while (enabled)
            {
                if (time >= Time.time)
                    _creature.HorizontalMovement(randValue);
                else
                    break;

                yield return null;
            }

            _isTurning = false;

            StartState(DoPatrol());
        }       
        
        private void StartState(IEnumerator coroutine)
        {
            _creature.VerticalMovement(0f);
            _creature.HorizontalMovement(0f);

            if (_current != null)
            {
                StopCoroutine(_current);
            }

            _current = coroutine;

            StartCoroutine(coroutine);
        }
    }
}