using Configs.Weapons;
using UnityEngine;
using WeaponSystem.Model;
using Zenject;

namespace Player.Installers
{
    public class PlayerWeaponInstaller : MonoInstaller
    {
        [SerializeField] private WeaponConfig _config;
        public override void InstallBindings()
        {
            Container.Bind<Weapon>().AsSingle().WithArguments(
                _config.Ammo, _config.IsRanged, _config.Name, _config.Description, _config.Cost);
        }
    }
}