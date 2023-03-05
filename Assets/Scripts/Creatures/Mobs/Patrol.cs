using Scripts.Components.ColliderBased;
using Scripts.Components.GoBased;
using System.Collections;
using UnityEngine;

namespace Scripts.Creatures.Mobs
{
    public class Patrol : MonoBehaviour
    {
        [SerializeField] private Checker _obstacleCheck;
        [SerializeField] private Creature _creature;
        [SerializeField] private int _direction;

        private Coroutine _coroutine;
        private int _randValue;

        public IEnumerator DoPatrol()
        {
            while (enabled)
            {
                _creature.Fire();

                if (_obstacleCheck.IsTochingLayer)
                {
                    _creature.VerticalMovement(0);
                    _creature.HorizontalMovement(0);
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
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            _coroutine = null;
        }

        private IEnumerator RandomRotate()
        {
            var randomTime = Random.Range(0.1f, 1.5f);
            var time = Time.time + randomTime;
            _randValue = RandomNumbers.RandomWithTwoNumber(-1, 1);

            while (true)
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