using UnityEngine.Events;
using UnityEngine;
using System;

namespace Skripts.Components
{
    public class HealthArmorComponent : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private int _armor;

        [SerializeField] private UnityEvent _onHPDamage;
        [SerializeField] private UnityEvent _onArmorDamage;
        [SerializeField] private UnityEvent _onDie;
        [SerializeField] private HealthChangeEvent _onChange;

        [HideInInspector]
        public bool _checkDamageBuff = false;

        private int _damageValue;
        private bool _checkDamageFlag = false;
        private bool _checkFlag = false;

        public void ApplyDamage(int damage)
        {
            _damageValue = damage;

            if (_checkDamageBuff)
            {
                ApplyBuffDamage();
            }

            if (!_checkDamageBuff)
            {
                if (_armor > 0)
                {
                    _armor -= _damageValue;
                    _onArmorDamage?.Invoke();
                }
                else if (_armor == 0)
                {
                    _health -= _damageValue;
                    _onChange?.Invoke(_health);
                    _onHPDamage?.Invoke();
                }

                if (_health <= 0)
                {
                    _onDie?.Invoke();
                }
            }
        }

        public void ApplyHeal(int healValue)
        {
            _health += healValue;
            _onChange?.Invoke(_health);
        }

        public void ApplyArmor(int armorValue)
        {
            _armor += armorValue;
        }

        public void DisabbleArmorBuff(int _usualArmor)
        {
            _armor = _usualArmor;
        }

        public void DamageBuff()
        {
            _damageValue += 1;
            //_checkDamageBuff = true;
        }

        public void RemoveDamageBuff()
        {
            _damageValue -= 1;
            //_checkDamageBuff = false;
        }

        private void ApplyBuffDamage()
        {
            if (_armor == 0 && _checkDamageFlag)
            {
                _health -= _damageValue;
                _onChange?.Invoke(_health);
            }

            if (_armor == 1)
            {
                _armor -= 1;
                _health -= 1;
                _onChange?.Invoke(_health);
                _checkDamageFlag = true;
            }

            if (_armor == 2 && _checkFlag)
            {
                _armor -= _damageValue;
                _checkDamageFlag = true;
                _checkFlag = false;
                _onHPDamage?.Invoke();
            }

            if (_armor > 2)
            {
                _armor -= _damageValue;
                _checkFlag = true;
                _checkDamageFlag = false;
                _onArmorDamage?.Invoke();
            }

            if (_health <= 0)
            {
                _onDie?.Invoke();
            }
        }

        public void SetHealth(int health)
        {
            _health = health;
        }

        [Serializable]
        public class HealthChangeEvent : UnityEvent<int>
        {
        }
    }
}