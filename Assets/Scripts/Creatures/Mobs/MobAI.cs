using Scripts.Components.ColliderBased;
using System.Collections;
using UnityEngine;

namespace Scripts.Creatures.Mobs
{
    public class MobAI : MonoBehaviour
    {
        [SerializeField] private Checker _vision;
        [SerializeField] private Checker _canAttack;
        [SerializeField] private Checker _leftTrigger;
        [SerializeField] private Checker _rightTrigger;

        [SerializeField] private float _attackCooldown = 1f;
        [SerializeField] private float _missHeroCooldown = 1f;

        private int _rotationDirection = 1;
        private IEnumerator _current;
        private BaseCreature _creature;
        private Patrol _patrol;
        private bool _isDead;

        private void Awake()
        {
            _creature = GetComponent<BaseCreature>();
            _patrol = GetComponent<Patrol>();
        }

        private void Start()
        {
            StartState(_patrol.DoPatrol());
        }

        public void InVision(GameObject go)
        {
            if (_isDead) return;

            StartState(LookAtHero());
        }

        private IEnumerator LookAtHero()
        {
            while (!_canAttack.IsTochingLayer && _vision.IsTochingLayer)
            {
                SetDirectionToTarget();

                yield return null;
            }

            yield return new WaitForSeconds(_missHeroCooldown);

            StartState(GoToHero());
        }

        private IEnumerator GoToHero()
        {
            while (_vision.IsTochingLayer)
            {
                if (_canAttack.IsTochingLayer)
                {
                    _creature.VerticalMovement(1f);
                    
                    StartState(Attack());
                }
                else
                {
                    SetDirectionToTarget();
                }

                yield return null;
            }

            yield return new WaitForSeconds(_missHeroCooldown);

            StartState(_patrol.DoPatrol());
        }

        private void SetDirectionToTarget()
        {
            if (_leftTrigger.IsTochingLayer)
                _rotationDirection = -1;
            if (_rightTrigger.IsTochingLayer)
                _rotationDirection = 1;

            _creature.HorizontalMovement(_rotationDirection);
        }

        private IEnumerator Attack()
        {
            while (_canAttack.IsTochingLayer)
            {    
                _creature.Fire();

                yield return new WaitForSeconds(_attackCooldown);
            }

            StartState(GoToHero());
        }

        private void StartState(IEnumerator coroutine)
        {
            _creature.VerticalMovement(0);
            _creature.HorizontalMovement(0);

            if (_current != null)
            {
                StopCoroutine(_current);
            }

            _current = coroutine;

            StartCoroutine(coroutine);
        }

        public void OnDie()
        {
            _isDead = true;

            if (_current != null)
            {
                StopCoroutine(_current);
            }
        }
    }
}