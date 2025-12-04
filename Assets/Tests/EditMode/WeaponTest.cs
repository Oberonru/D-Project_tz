using NUnit.Framework;
using WeaponSystem.Model;

namespace Tests.EditMode
{
    public class WeaponTest
    {
        [Test]
        public void RangeAttack_CheckAmmoAmount()
        {
            var weapon = new Weapon(5, true, "dubina", "dubina_obiknovennaja", 20);

            weapon.RangedAttack();
            
            Assert.AreEqual(4, weapon.Ammo);
        }
        
        [Test]
        public void RangedAttack_DoesNotGoBelowZero()
        {
            var weapon = new Weapon(0, true, "dubina", "dubina_obiknovennaja", 20);

            weapon.RangedAttack();

            Assert.AreEqual(0, weapon.Ammo);
        }
    }
}