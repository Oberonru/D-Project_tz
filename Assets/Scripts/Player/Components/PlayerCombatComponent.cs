using UnityEngine;
using WeaponSystem;

namespace Player.Components
{
    public class PlayerCombatComponent : MonoBehaviour
    {
        [SerializeField] private WeaponComponent _weapon;

        private void OnValidate()
        {
            if (_weapon == null) _weapon = GetComponent<WeaponComponent>();
        }

        public void Attack()
        {
            if (_weapon.CurrentWeapon.IsRanged)
            {
                _weapon.RangedAttack();
                Debug.Log("Ranged attack");
            }
            else
            {
                _weapon.MeleeAttack();
                Debug.Log("Melee attack");
            }
        }
    }
}