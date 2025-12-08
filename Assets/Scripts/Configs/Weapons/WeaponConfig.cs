using Configs.ItemEntities;
using Items;
using UnityEngine;
using WeaponSystem.Model;

namespace Configs.Weapons
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "Configs/Weapon/WeaponConfig")]
    public class WeaponConfig : ItemConfig
    {
        [SerializeField] private int _ammo;
        [SerializeField] private bool _isRanged;

        public int Ammo => _ammo;
        public bool IsRanged => _isRanged;

        public override Item CreateItem()
        {
            return new Weapon(_ammo, _isRanged, Name, Description, Cost);
        }
    }
}