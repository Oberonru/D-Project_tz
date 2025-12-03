using System;
using HealthSystem.Model;
using NUnit.Framework;

namespace Tests.EditMode
{
    public class HealthTest
    {
        [Test]
        public void TakeDamage_ReducesHealth()
        {
            var health = new Health(100);
            health.TakeDamage(10);
            Assert.AreEqual(90, health.CurrentHealth);
        }

        [Test]
        public void TakeDamage_NegativeResult()
        {
            Assert.Throws<ArgumentException>(() => new Health(-1));
        }

        [Test]
        public void TakeDamage_GreaterValue()
        {
            var health = new Health(100);
            health.TakeDamage(101);
            Assert.AreEqual(0, health.CurrentHealth);
        }
        [Test]
        public void TakeDamage_TriggerOnDamage()
        {
            var health = new Health(100);
            var isTriggered = false;
            
            health.OnDamaged += () => { isTriggered = true; };
            health.TakeDamage(10);
            
            Assert.IsTrue(isTriggered);
        }
        
        [Test]
        public void TakeDamage_TriggerOnDeath()
        {
            var health = new Health(100);
            var isTriggered = false;
            
            health.TakeDamage(100);
            
            
            health.OnDeath += () => { isTriggered = true; };
            
            Assert.IsTrue(isTriggered);
        }
        
    }
}