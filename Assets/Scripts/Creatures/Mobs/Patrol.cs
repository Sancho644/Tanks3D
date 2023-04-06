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
        [SerializeField] private int _direction = 1;

        private Coroutine _coroutine = default;
        private int _randValue = 1;

        public IEnumerator DoPatrol()
        {
            while (enabled)
            {
                _creature.Fire();

                if (_obstacleCheck.IsTochingLayer)
                {
                    TryStop();

                    break;
                }
                else
                {
                    _creature.VerticalMovement(_direction);
                }

                yield return null;
            }

            _coroutine = StartCoroutine(RandomRotate());
        }

        private void TryStop()
        {
            _creature.VerticalMovement(0);
            _creature.HorizontalMovement(0);

            if (_coroutine != null)
                StopCoroutine(_coroutine);
            _coroutine = null;
        }

        private IEnumerator RandomRotate()
        {
            var randomTime = Random.Range(0.1f, 1.5f);
            var time = Time.time + randomTime;
            _randValue = RandomNumbers.RandomWithTwoNumber(-1, 1);

            while (enabled)
            {
                if (time >= Time.time)
                    _creature.HorizontalMovement(_randValue);
                else                  
                    break;

                yield return null;
            }

            TryStop();
            _coroutine = StartCoroutine(DoPatrol());
        }
    }
}