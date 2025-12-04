using Player;
using UnityEngine;
using Zenject;

namespace DevTools
{
    public class CheckPlayerStats : MonoBehaviour
    {
        [Inject] private IPlayerInstance _player;
        
        private void Update()
        {
            if (_player == null) return;
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Max Health: " + _player.PlayerHealth.MaxHealth);
                Debug.Log("Current Health: " + _player.PlayerHealth.CurrentHealth);
            }
        }
    }
}