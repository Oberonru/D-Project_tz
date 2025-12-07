using Items;
using Items.Instances;
using UnityEngine;
using WeaponSystem.Model;

namespace Player.Components
{
    public class Equipment : MonoBehaviour
    {
        public Item PrimaryWeaponSlot => _primaryWeapon;
        private Item _primaryWeapon;

        public Item SecondaryWeaponSlot => _secondaryWeaponSlot;
        private Item _secondaryWeaponSlot;

        public Item UntilSlot => _until;
        private Item _until;

        public void Equip(Item item)
        {
            switch (item)
            {
                case Weapon weapon when _secondaryWeaponSlot == null:
                    _primaryWeapon = weapon;
                    break;
                case Weapon weapon:
                    _secondaryWeaponSlot = weapon;
                    break;
                case UntilItem until:
                    _until = until;
                    break;
            }
        }

        public void Unequip(Item item)
        {
        }
    }
}