using System;
using UnityEngine;
using WeaponSystem.Model;

namespace WeaponSystem
{
    public class WeaponComponent : MonoBehaviour
    {
        public event Action OnAttacked;
        public bool IsRanged => _weaponModel.IsRanged;
        public int Ammo => _weaponModel.Ammo;

        public Weapon CurrentWeapon => _weaponModel;
        private Weapon _weaponModel;

        private void OnDestroy()
        {
            if (_weaponModel != null)
            {
                _weaponModel.OnAttacked -= OnAttacked;
            }
        }

        public void Init(Weapon weapon)
        {
            _weaponModel = weapon;
        }

        public void RangedAttack()
        {
            if (_weaponModel == null) return;

            if (_weaponModel.Ammo <= 0)
            {
                Debug.Log("No ammo");
                return;
            }

            if (_weaponModel.IsRanged)
                _weaponModel.RangedAttack();
        }

        public void MeleeAttack()
        {
            if (_weaponModel == null) return;

            if (!_weaponModel.IsRanged)
                _weaponModel.MeleeAttack();
        }

        private void HandleAttack()
        {
            OnAttacked?.Invoke();
        }
    }
}