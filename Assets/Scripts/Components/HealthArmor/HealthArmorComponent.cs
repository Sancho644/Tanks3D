namespace Scripts.Components.HealthArmor
{
    using UnityEngine;
    using System;

    public class HealthArmorComponent : MonoBehaviour
    {
        [SerializeField] private int _health = 1;
        [SerializeField] private int _armor = 0;

        private bool _damageBuff = false;

        public bool DamageBuff { get => _damageBuff; set => _damageBuff = value; }

        public event Action OnHpDamage = default;
        public event Action<int> OnArmorDamage = default;
        public event Action OnDie = default;
        public event Action<int> OnHpChange = default;

        public void ModifyHealth(int value)
        {
            if (_armor > 0)
            {
                ModifyArmor(value);
            }
            else if (_armor == 0)
            {
                var health = _health;
                health += value;

                _health = Mathf.Clamp(health, 0, 3);

                OnHpChange?.Invoke(_health);
                OnHpDamage?.Invoke();
            }

            if (_health <= 0)
            {
                OnDie?.Invoke();
            }
        }

        public void ModifyArmor(int value)
        {
            var armor = _armor;
            armor += value;

            _armor = Mathf.Clamp(armor, 0, 3);

            OnArmorDamage?.Invoke(_armor);
        }


        public void ApplyArmor(int armorValue)
        {
            _armor += armorValue;
        }

        public void DisabbleArmorBuff(int _usualArmor)
        {
            _armor = _usualArmor;
        }

        public void SetHealth(int health)
        {
            _health = health;
        }
    }
}