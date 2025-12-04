using HealthSystem;
using Player.Components;
using WeaponSystem;

namespace Player
{
    public interface IPlayerInstance
    {
        HealthComponent PlayerHealth { get; }
        WeaponComponent Weapon { get; }
        PlayerCombatComponent PlayerCombatComponent { get; }
    }
}