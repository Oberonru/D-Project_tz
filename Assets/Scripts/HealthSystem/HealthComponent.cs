using System;
using HealthSystem.Model;
using UnityEngine;

namespace HealthSystem
{
    public class HealthComponent : MonoBehaviour
    {
        private IHealth _healthModel;
        public int MaxHealth => _healthModel.MaxHealth;
        public int CurrentHealth => _healthModel.CurrentHealth;
        public event Action<int, int> OnHealthChanged;
        public event Action OnDamaged;
        public event Action OnDeath;

        private void OnDisable()
        {
            if (_healthModel != null)
                Unsubscribe();
        }

        private void OnDestroy()
        {
            if (_healthModel != null) Unsubscribe();
        }


        public void Init(IHealth health)
        {
            if (_healthModel != null) Unsubscribe();
            
            _healthModel = health;
            Subscribe();
        }
        // [Inject]
        // public void Construct(IHealth health)
        // {
        //    if (_healthModel != null) Unsubscribe();
        //
        //     _healthModel = health;
        //
        //     Subscribe();
        // }

        public void TakeDamage(int damage)
        {
            if (_healthModel == null) return;

            _healthModel.TakeDamage(damage);
        }

        public void Heal(int heal)
        {
            _healthModel.Heal(heal);
        }

        private void Unsubscribe()
        {
            _healthModel.OnHealthChange -= HandleHealthChanged;
            _healthModel.OnDeath -= HandleDeath;
            _healthModel.OnDamaged -= HandleDamage;
        }

        private void Subscribe()
        {
            _healthModel.OnHealthChange += HandleHealthChanged;
            _healthModel.OnDeath += HandleDeath;
            _healthModel.OnDamaged += HandleDamage;
        }

        private void HandleHealthChanged(int current, int max)
        {
            OnHealthChanged?.Invoke(current, max);
        }

        private void HandleDamage()
        {
            OnDamaged?.Invoke();
        }

        private void HandleDeath()
        {
            OnDeath?.Invoke();
        }
    }
}