using UnityEngine;
using System.Collections;
using PixelCrew.Components.ColliderBased;
using PixelCrew.Components.GoBased;
using PixelCrew.Creatures.Mobs.Patrolling;
using PixelCrew.Animations;
using PixelCrew.Components;

namespace PixelCrew.Creatures.Mobs
{
    public class MobAI : MonoBehaviour
    {
        [SerializeField] private ColliderCheck _vision;
        [SerializeField] private ColliderCheck _canAttack;

        [SerializeField] private float _alarmDelay = 0.5f;
        [SerializeField] private float _attackCooldown = 1f;
        [SerializeField] private float _missHeroCooldown = 0.5f;

        [SerializeField] private float _horizontalTrashold = 0.5f;

        private IEnumerator _current;
        private GameObject _target;

        private static readonly int IsDeadKey = Animator.StringToHash("is-dead");

        private PlatformPatrol _platformPatrol;
        private SpawnListComponent _particles;
        private Creature _creature;
        private Animator _animator;
        private Patrol _patrol;
        private bool _isDead;

        private void Awake()
        {
            _platformPatrol = GetComponent<PlatformPatrol>();
            _particles = GetComponent<SpawnListComponent>();
            _creature = GetComponent<Creature>();
            _animator = GetComponent<Animator>();
            _patrol = GetComponent<Patrol>();
        }

        private void Start()
        {
            StartState(_patrol.DoPatrol());
        }

        public void OnHeroInVision(GameObject go)
        {
            if (_isDead) return;

            _target = go;

            StartState(AgroToHero());
        }

        private IEnumerator AgroToHero()
        {
            LookAtHero();
            _particles.Spawn("Exclamation");
            yield return new WaitForSeconds(_alarmDelay);

            StartState(GoToHero());
        }

        private void LookAtHero()
        {
            var direction = GetDirectionToTarget();
            _creature.SetDirection(Vector2.zero);
            _creature.UpdateSpriteDirection(direction);

        }

        private IEnumerator GoToHero()
        {
            while (_vision.IsTochingLayer)
            {
                if (_canAttack.IsTochingLayer)
                {
                    StartState(Attack());
                }
                else
                {
                    var horizontalDelta = Mathf.Abs(_target.transform.position.x - transform.position.x);
                    if (horizontalDelta <= _horizontalTrashold)
                        _creature.SetDirection(Vector2.zero);
                    else
                        SetDirectionToTarget();
                }

                yield return null;
            }

            _creature.SetDirection(Vector2.zero);
            _particles.Spawn("MissHero");
            yield return new WaitForSeconds(_missHeroCooldown);

            StartState(_patrol.DoPatrol());
        }

        private IEnumerator Attack()
        {
            while (_canAttack.IsTochingLayer)
            {
                _creature.Attack();
                yield return new WaitForSeconds(_attackCooldown);
            }

            StartState(GoToHero());
        }

        private void SetDirectionToTarget()
        {
            var direction = GetDirectionToTarget();
            if (!_platformPatrol.ObstacleCheck.IsTochingLayer & _platformPatrol.GroundCheck.IsTochingLayer)
            {
                _creature.SetDirection(direction);
            }
            else
            {
                _creature.SetDirection(Vector2.zero);
            }
        }

        private Vector2 GetDirectionToTarget()
        {
            var direction = _target.transform.position - transform.position;
            direction.y = 0;
            return direction.normalized;
        }

        private void StartState(IEnumerator coroutine)
        {
            _creature.SetDirection(Vector2.zero);

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
            _animator.SetBool(IsDeadKey, true);

            _creature.SetDirection(Vector2.zero);
            if (_current != null)
            {
                StopCoroutine(_current);
            }
        }
    }
}