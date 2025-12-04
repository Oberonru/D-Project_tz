using System;
using UnityEngine;
using WeaponSystem.Model;
using Zenject;

namespace WeaponSystem
{
    public class WeaponComponent : MonoBehaviour
    {
        public event Action OnAttacked;
        public bool IsRanged => _weaponModel.IsRanged;
        public int Ammo => _weaponModel.Ammo;
        private Weapon _weaponModel;

        [Inject]
        public void Construct(Weapon weapon)
        {
            _weaponModel = weapon;

            _weaponModel.OnAttacked += HandleAttack;
        }

        private void OnDestroy()
        {
            if (_weaponModel != null)
            {
                _weaponModel.OnAttacked -= OnAttacked;
            }
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