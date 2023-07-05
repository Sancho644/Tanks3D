using System.Collections;
using System.Collections.Generic;
using Components;
using Components.Audio;
using Components.GoBased;
using Components.HealthArmor;
using UnityEngine;

namespace Creatures.Mobs
{
    public class BaseCreature : MonoBehaviour
    {
        [SerializeField] private float _speed = 30f;
        [SerializeField] private float _rotationSpeed = 20f;
        [SerializeField] private List<MeshRenderer> _tanksRenderersList;

        [SerializeField] protected Cooldown _attackCooldown;
        [SerializeField] protected HealthArmorComponent _healthArmor;
        [SerializeField] protected SpawnComponent _attack;

        private float _horizontal;
        private float _vertical;
        protected PlaySoundsComponent _sounds;

        private Rigidbody _rigidbody;
        private Color _defaultColor;
        private List<Material> _tanksMaterialsList = new List<Material>();

        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _sounds = GetComponent<PlaySoundsComponent>();
            _defaultColor = _tanksRenderersList[0].material.color;

            foreach (var render in _tanksRenderersList)
            {
                _tanksMaterialsList.Add(render.material);
            }
        }

        private void FixedUpdate()
        {
            VerticalMovement(_vertical);
            HorizontalMovement(_horizontal);
        }

        private void VerticalMovement(float vertical)
        {
            _rigidbody.AddForce(vertical * _speed * transform.forward);
        }
        
        private void HorizontalMovement(float horizontal)
        {
            _rigidbody.transform.Rotate(0, horizontal * _rotationSpeed, 0);
        }
        
        public void SetVerticalDirection(float value)
        {
            _vertical = value;
        }

        public void SetHorizontalDirection(float value)
        {
            _horizontal = value;
        }

        public virtual void Fire()
        {
            if (_attackCooldown.IsReady)
            {
                _attack.Spawn();
                _attackCooldown.Reset();
                _sounds.Play("Fire");
            }
        }

        protected void OnTakeHealthDamage()
        {
            _sounds.Play("HitDamage");
            StartCoroutine(StartDamageAnimation());
        }

        private IEnumerator StartDamageAnimation()
        {
            while (enabled)
            {
                foreach (var tankMaterial in _tanksMaterialsList)
                {
                    tankMaterial.color = Color.white;
                }

                yield return new WaitForSeconds(0.1f);

                foreach (var tankMaterial in _tanksMaterialsList)
                {
                    tankMaterial.color = _defaultColor;
                }

                break;
            }
        }
    }
}