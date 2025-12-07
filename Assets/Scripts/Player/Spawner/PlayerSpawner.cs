using Configs.Player;
using HealthSystem.Model;
using Player.Factory;
using UnityEngine;
using WeaponSystem.Model;
using Zenject;

namespace Player.Spawner
{
    public class PlayerSpawner : MonoInstaller
    {
        [Inject] private IPlayerFactory _factory;
        [Inject] private PlayerConfig _config;
        [SerializeField] private PlayerInstance _prefab;

        public override void InstallBindings()
        {
            var player = _factory.Create(_prefab, Vector3.zero, Quaternion.identity, null) as PlayerInstance;
            var healthModel = new Health(_config.MaxHealth);

            player.PlayerHealth.Init(healthModel);

            foreach (var i in _config.StartItems)
            {
                var item = i.CreateItem();
                player.PlayerInventory.Add(item);

                if (item is Weapon weapon)
                {
                    player.Weapon.Init(weapon);
                    player.Equipment.Equip(weapon);
                }
            }

            Container.Bind<IPlayerInstance>().FromInstance(player).AsSingle();
        }
    }
}