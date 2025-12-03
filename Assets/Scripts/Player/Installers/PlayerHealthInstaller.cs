using Configs.Player;
using HealthSystem.Model;
using UnityEngine;
using Zenject;

namespace Player.Installers
{
    public class PlayerHealthInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _config;
        
        public override void InstallBindings()
        {
            Container.Bind<IHealth>().To<Health>().AsSingle().WithArguments(_config.MaxHealth);
        }
    }
}