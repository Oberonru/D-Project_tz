using HealthSystem;
using Player.Components;
using UnityEngine;
using WeaponSystem;

namespace Player
{
    [RequireComponent(typeof(HealthComponent))]
    [RequireComponent(typeof(WeaponComponent))]
    [RequireComponent(typeof(PlayerCombatComponent))]
    [RequireComponent(typeof(PlayerInventory))]
    [RequireComponent(typeof(Equipment))]
    [RequireComponent(typeof(PlayerDataComponent))]
    public class PlayerInstance : MonoBehaviour, IPlayerInstance
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private WeaponComponent _weapon;
        [SerializeField] private PlayerCombatComponent playerCombatComponent;
        [SerializeField] private PlayerInventory _inventory;
        [SerializeField] private Equipment _equipment;
        [SerializeField] private PlayerDataComponent _playerData;

        public HealthComponent PlayerHealth => _healthComponent;
        public WeaponComponent Weapon => _weapon;

        public PlayerCombatComponent PlayerCombatComponent => playerCombatComponent;
        public PlayerInventory PlayerInventory => _inventory;
        public Equipment Equipment => _equipment;
        public PlayerDataComponent PlayerData => _playerData;

        private void OnValidate()
        {
            if (_healthComponent == null) _healthComponent = GetComponent<HealthComponent>();
            if (_weapon == null) _weapon = GetComponent<WeaponComponent>();
            if (playerCombatComponent == null) playerCombatComponent = GetComponent<PlayerCombatComponent>();
            if (_inventory == null) _inventory = GetComponent<PlayerInventory>();
            if (_equipment == null) _equipment = GetComponent<Equipment>();
            if (_playerData == null) _playerData = GetComponent<PlayerDataComponent>();
        }
    }
}