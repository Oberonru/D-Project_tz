using Configs.Player;
using UnityEngine;
using Zenject;

namespace Player.Spawner
{
    public class PlayerSpawner : MonoInstaller
    {
        [Inject] private PlayerConfig _config;
        [SerializeField] private PlayerInstance _prefab;
        [SerializeField] private bool _isSingle;

        public override void InstallBindings()
        {
            var player = Container.InstantiatePrefabForComponent<PlayerInstance>(_prefab);
            if (_isSingle)
                Container.Bind<IPlayerInstance>().FromInstance(player).AsSingle();
            else
                Container.Bind<IPlayerInstance>().FromInstance(player);
        }
    }
}