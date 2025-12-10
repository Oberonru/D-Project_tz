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
                if (_player.PlayerInventory.Inventory == null || _player.PlayerInventory.Inventory.Count == 0)
                {
                    Debug.Log("Inventory null or empty");
                    return;
                }

                foreach (var item in _player.PlayerInventory.Inventory)
                {
                    Debug.Log(item.Name);
                }

                Debug.Log("Current equipped weapon: " + _player.Weapon?.CurrentWeapon?.Name);
            }
        }
    }
}