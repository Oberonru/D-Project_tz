using System;

namespace HealthSystem.Model
{
    public interface IHealth
    {
        int MaxHealth { get; }
        int CurrentHealth { get; }
        void TakeDamage(int damage);
        void Heal(int heal);
        event Action<int, int> OnHealthChange;
        event Action OnDamaged;
        event Action OnDeath;
    }
}