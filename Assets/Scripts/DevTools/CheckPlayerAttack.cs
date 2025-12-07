using Configs.Input;
using Player;
using UnityEngine;
using Zenject;

namespace DevTools
{
    public class CheckPlayerAttack : MonoBehaviour
    {
        [Inject] private IPlayerInstance _player;
        [Inject] private KeyConfig _config;

        private void Update()
        {
            if (Input.GetKeyDown(_config.CheckPlayerAttack))
            {
                _player.PlayerCombatComponent.Attack();
            }
        }
    }
}