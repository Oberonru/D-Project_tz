using HealthSystem;
using Infrastructure.Factory;
using Player.Components;
using WeaponSystem;

namespace Player
{
    public interface IPlayerInstance : IFactoryObject
    {
        HealthComponent PlayerHealth { get; }
        WeaponComponent Weapon { get; }
        PlayerCombatComponent PlayerCombatComponent { get; }
        PlayerInventory PlayerInventory { get; }
    }
}