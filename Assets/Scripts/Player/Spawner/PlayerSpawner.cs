using Configs.Player;
using HealthSystem;
using HealthSystem.Model;
using Player.Factory;
using UnityEngine;
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
            var health = player.GetComponent<HealthComponent>();
            var healthModel = new Health(_config.MaxHealth);
            
            health.Init(healthModel);
            

            Container.Bind<IPlayerInstance>().FromInstance(_prefab).AsSingle();
        }
    }
}