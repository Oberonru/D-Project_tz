using Configs.Input;
using Player;
using UnityEngine;
using Zenject;

namespace DevTools
{
    public class CheckInventory : MonoBehaviour
    {
        [Inject] private IPlayerInstance _player;
        [Inject] private KeyConfig _config;

        private void Update()
        {
            if (_player == null) return;

            if (Input.GetKeyDown(_config.CheckInventoryKey))
            {
                foreach (var item in _player.PlayerInventory.Inventory)
                {
                    Debug.Log(item.Name);
                }
                
                Debug.Log("Current equipped weapon: " + _player.Weapon.CurrentWeapon.Name);
            }
        }
    }
}