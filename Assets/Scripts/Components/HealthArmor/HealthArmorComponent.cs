using System;
using UnityEngine;

namespace Components.HealthArmor
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
            Debug.Log($"armor {_armor}");
            Debug.Log($"health {_health}");
            if (_armor > 0)
            {
                ModifyArmor(value);
            }
            else if (_armor == 0)
            {
                _health += value;

                _health = Mathf.Clamp(_health, 0, 3);
                Debug.Log(value);
                Debug.Log(_health);
                Debug.Log("health");
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
            Debug.Log(value);
            Debug.Log(_armor);
            Debug.Log("armor");
            _armor = Mathf.Clamp(_armor, 0, 3);

            OnArmorChange?.Invoke(_armor);
        }


        public void ApplyArmor(int armorValue)
        {
            _armor += armorValue;
        }

        public void DisableArmorBuff(int usualArmor)
        {
            _armor = usualArmor;
        }

        public void SetHealth(int health)
        {
            _health = health;
        }
    }
}