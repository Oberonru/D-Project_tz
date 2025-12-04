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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
            }
        }

        private void Attack()
        {
            if (_weapon.IsRanged)
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