using Scripts.Components.ColliderBased;
using Scripts.Components.GoBased;
using System.Collections;
using Creatures.Mobs;
using UnityEngine;

namespace Scripts.Creatures.Mobs
{
    public class MobAI : MonoBehaviour
    {
        [SerializeField] private EnterTriggerComponent _vision;
        [SerializeField] private Checker _canAttack;
        [SerializeField] private Checker _leftTrigger;
        [SerializeField] private Checker _rightTrigger;

        [SerializeField] private float _attackCooldown = 1f;
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
            float rand = RandomNumbers.RandomWithTwoNumber(-1, 1);

            while (_vision.IsTouchingLayer)
            {
                if (!_leftTrigger.IsTouchingLayer && !_rightTrigger.IsTouchingLayer)
                {
                    _creature.HorizontalMovement(rand);
                }

                if (_leftTrigger.IsTouchingLayer)
                {
                    _creature.HorizontalMovement(-1f);
                }

                if (_rightTrigger.IsTouchingLayer)
                {
                    _creature.HorizontalMovement(1f);
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

                yield return new WaitForSeconds(_attackCooldown);
            }

            StartState(SetDirectionToTarget());
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

        private void OnDestroy()
        {
            _vision.OnEnterTriggered -= OnInVision;
        }
    }
}