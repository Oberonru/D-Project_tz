using Configs.Input;
using Player;
using UnityEngine;
using Zenject;

namespace DevTools
{
    public class CheckPlayerHealth : MonoBehaviour
    {
        [Inject] private IPlayerInstance _player;
        [Inject] private KeyConfig _config;
        
        private void Update()
        {
            if (_player == null) return;
            
            if (Input.GetKeyDown(_config.CheckPlayerHealth))
            {
                Debug.Log("Max Health: " + _player.PlayerHealth.MaxHealth);
                Debug.Log("Current Health: " + _player.PlayerHealth.CurrentHealth);
            }
        }
    }
}