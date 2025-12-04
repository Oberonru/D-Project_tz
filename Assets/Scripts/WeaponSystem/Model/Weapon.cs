using System;
using Items;
using UnityEngine;

namespace WeaponSystem.Model
{
    [Serializable]
    public class Weapon : Item
    {
        public event Action OnAttacked;

        public bool IsRanged
        {
            get => _isRanged;
            set => _isRanged = value;
        }

        private bool _isRanged;

        public int Ammo
        {
            get => _ammo;
            set => _ammo = Mathf.Clamp(value, 0, int.MaxValue);
        }

        private int _ammo;

        public Weapon(int ammo, bool isRanged, string name, string description, int cost)
        {
            Ammo = ammo;
            IsRanged = isRanged;
            Name = name;
            Description = description;
            Cost = cost;
        }

        public void MeleeAttack()
        {
            if (IsRanged) return;

            OnAttacked?.Invoke();
        }

        public void RangedAttack()
        {
            if (!IsRanged) return;

            Ammo--;

            OnAttacked?.Invoke();
        }
    }
}