using System;
using UnityEngine;

namespace Components.HealthArmor
{
    public class HealthArmorComponent : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private int _armor;

        private const int MaxHealthArmor = 3;
        private const int MinHealthArmor = 0;

        public event Action OnDamage;
        public event Action<int> OnArmorChange;
        public event Action OnDie;
        public event Action<int> OnHpChange;

        public void ModifyHealth(int value)
        {
            if (value < 0)
            {
                OnDamage?.Invoke();
            }

            if (_armor > 0)
            {
                ModifyArmor(value);
            }
            else if (_armor == 0)
            {
                _health += value;

                _health = Mathf.Clamp(_health, MinHealthArmor, MaxHealthArmor);
                OnHpChange?.Invoke(_health);
            }

            if (_health <= 0)
            {
                OnDie?.Invoke();
            }
        }

        public void ModifyArmor(int value)
        {
            _armor += value;
            _armor = Mathf.Clamp(_armor, MinHealthArmor, MaxHealthArmor);

            OnArmorChange?.Invoke(_armor);
        }

        public void ApplyHeal(int value)
        {
            _health += value;
            _health = Mathf.Clamp(_health, MinHealthArmor, MaxHealthArmor);

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