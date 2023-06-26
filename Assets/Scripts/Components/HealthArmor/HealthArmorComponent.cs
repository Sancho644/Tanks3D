using System;
using UnityEngine;

namespace Components.HealthArmor
{
    public class HealthArmorComponent : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private int _armor;

        private int _maxHealthArmor = 3;
        private int _minHealthArmor = 0;
        
        public event Action OnHpDamage;
        public event Action<int> OnArmorChange;
        public event Action OnDie;
        public event Action<int> OnHpChange;

        public void ModifyHealth(int value)
        {
            if (_armor > 0)
            {
                ModifyArmor(value);
            }
            else if (_armor == 0)
            {
                _health += value;

                _health = Mathf.Clamp(_health, _minHealthArmor, _maxHealthArmor);
                OnHpChange?.Invoke(_health);

                if (value < 0)
                {
                    OnHpDamage?.Invoke();
                }
            }

            if (_health <= 0)
            {
                OnDie?.Invoke();
            }
        }

        public void ModifyArmor(int value)
        {
            _armor += value;
            _armor = Mathf.Clamp(_armor, _minHealthArmor, _maxHealthArmor);

            OnArmorChange?.Invoke(_armor);
        }

        public void ApplyHeal(int value)
        {
            _health += value;
            _health = Mathf.Clamp(_health, _minHealthArmor, _maxHealthArmor);
            
            OnHpChange?.Invoke(_health);
        }

        public void SetHealth(int health)
        {
            _health = health;
        }

        public void SetArmor(int armor)
        {
            _armor = armor;
        }
    }
}