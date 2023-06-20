using System.Collections;
using Components.ColliderBased;
using Scripts.Components.GoBased;
using UnityEngine;

namespace Creatures.Mobs
{
    public class Patrol : MonoBehaviour
    {
        [SerializeField] private Checker _obstacleCheck;
        [SerializeField] private Enemy _creature;
        [SerializeField] private float _direction = 1f;

        private IEnumerator _current;
        private bool _isTurning;

        public IEnumerator DoPatrol()
        {
            while (!_obstacleCheck.IsTouchingLayer && !_isTurning)
            {
                _creature.Fire();

                if (_obstacleCheck.IsTouchingLayer)
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
            var randomTime = Random.Range(0.1f, 1.5f);
            var time = Time.time + randomTime;
            var randValue = RandomNumbers.RandomWithTwoNumber(-1f, 1f);
            
            _isTurning = true;

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
                StopCoroutine(_current);

            _current = coroutine;

            StartCoroutine(coroutine);
        }
    }
}