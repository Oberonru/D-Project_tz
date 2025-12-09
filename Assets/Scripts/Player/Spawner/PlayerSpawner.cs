using Configs.Player;
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

            Container.Bind<IPlayerInstance>().FromInstance(player).AsSingle();
        }
    }
}