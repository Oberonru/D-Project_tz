using System;
using UnityEngine;

namespace HealthSystem.Model
{
    [Serializable]
    public class Health : IHealth
    {
        public event Action<int, int> OnHealthChange;
        public event Action OnDamaged;
        public event Action OnDeath;

        public int MaxHealth
        {
            get => _maxHealth;
            set => _maxHealth = value;
        }

        public int CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = Mathf.Clamp(value, 0, _maxHealth);
                OnHealthChange?.Invoke(_currentHealth, _maxHealth);

                if (_currentHealth <= 0)
                {
                    OnDeath?.Invoke();
                }
            }
        }

        [SerializeField] private int _maxHealth;
        private int _currentHealth;

        public Health(int maxHealth)
        {
            if (maxHealth <= 0) throw new ArgumentException("MaxHealth must be positive");

            _maxHealth = maxHealth;
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (damage <= 0 || _currentHealth <= 0) return;

            CurrentHealth -= damage;

            OnDamaged?.Invoke();
        }

        public void Heal(int heal)
        {
            if (heal <= 0 || _currentHealth >= _maxHealth) return;
            CurrentHealth += heal;
        }
    }
}