using System.Collections;
using Components.ColliderBased;
using Components.GoBased;
using UnityEngine;

namespace Creatures.Mobs
{
    public class MobAI : MonoBehaviour
    {
        [SerializeField] private EnterTriggerComponent _vision;
        [SerializeField] private Checker _canAttack;
        [SerializeField] private Checker _leftTrigger;
        [SerializeField] private Checker _rightTrigger;
        [SerializeField] private float _missHeroCooldown = 1f;

        private IEnumerator _current;
        private BaseCreature _creature;
        private Patrol _patrol;

        private void Awake()
        {
            _creature = GetComponent<BaseCreature>();
            _patrol = GetComponent<Patrol>();
        }

        private void Start()
        {
            StartState(_patrol.DoPatrol());

            _vision.OnEnterTriggered += OnInVision;
        }

        private void OnInVision(GameObject go)
        {
            _patrol.TryStop();

            StartState(SetDirectionToTarget());
        }

        private IEnumerator SetDirectionToTarget()
        {
            var rand = RandomNumbers.RandomWithTwoNumber(-1, 1);

            while (_vision.IsTouchingLayer)
            {
                if (!_leftTrigger.IsTouchingLayer && !_rightTrigger.IsTouchingLayer)
                {
                    _creature.SetHorizontalDirection(rand);
                }

                if (_leftTrigger.IsTouchingLayer)
                {
                    _creature.SetHorizontalDirection(-1f);
                }

                if (_rightTrigger.IsTouchingLayer)
                {
                    _creature.SetHorizontalDirection(1f);
                }

                if (_canAttack.IsTouchingLayer)
                {
                    StartState(Attack());
                }

                yield return null;
            }

            yield return new WaitForSeconds(_missHeroCooldown);

            StartState(_patrol.DoPatrol());
        }

        private IEnumerator Attack()
        {
            while (_canAttack.IsTouchingLayer)
            {
                _creature.Fire();

                yield return null;
            }

            StartState(SetDirectionToTarget());
        }

        private void StartState(IEnumerator coroutine)
        {
            _creature.SetVerticalDirection(0f);
            _creature.SetHorizontalDirection(0f);

            if (_current != null)
                StopCoroutine(_current);

            _current = coroutine;

            StartCoroutine(coroutine);
        }

        private void OnDestroy()
        {
            _vision.OnEnterTriggered -= OnInVision;
        }
    }
}