using HealthSystem;
using Player.Components;
using UnityEngine;
using WeaponSystem;

namespace Player
{
    [RequireComponent(typeof(HealthComponent))]
    [RequireComponent(typeof(WeaponComponent))]
    [RequireComponent(typeof(PlayerCombatComponent))]
    public class PlayerInstance : MonoBehaviour, IPlayerInstance
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private WeaponComponent _weapon;
        [SerializeField] private PlayerCombatComponent playerCombatComponent;

        public HealthComponent PlayerHealth => _healthComponent;
        public WeaponComponent Weapon => _weapon;
        public PlayerCombatComponent PlayerCombatComponent => playerCombatComponent;

        private void OnValidate()
        {
            if (_healthComponent == null) _healthComponent = GetComponent<HealthComponent>();
            if (_weapon == null) _weapon = GetComponent<WeaponComponent>();
            if (playerCombatComponent == null) playerCombatComponent = GetComponent<PlayerCombatComponent>();
        }

        private void Update()
        {
            //Debug.Log(_weapon.Ammo + " Ammo");
        }
    }
}