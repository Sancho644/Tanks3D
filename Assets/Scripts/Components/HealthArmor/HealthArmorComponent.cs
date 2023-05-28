using UnityEngine;
using System;

namespace Scripts.Components.HealthArmor
{
    public class HealthArmorComponent : MonoBehaviour
    {
        [SerializeField] private int _health = 1;
        [SerializeField] private int _armor = 0;

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

                _health = Mathf.Clamp(_health, 0, 3);

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

            _armor = Mathf.Clamp(_armor, 0, 3);

            OnArmorChange?.Invoke(_armor);
        }


        public void ApplyArmor(int armorValue)
        {
            _armor += armorValue;
        }

        public void DisabbleArmorBuff(int usualArmor)
        {
            _armor = usualArmor;
        }

        public void SetHealth(int health)
        {
            _health = health;
        }
    }
}