using Configs.Input;
using Player;
using Services;
using Storage;
using UnityEngine;
using Zenject;

namespace DevTools
{
    public class CheckSaveHealth : MonoBehaviour
    {
        [Inject] private IPlayerInstance _player;
        [Inject] private KeyConfig _config;
        [Inject] private StorageService _storage;

        private async void Update()
        {
            if (Input.GetKeyDown(_config.CheckSave))
            {
                PlayerData data = _player.PlayerData.Data;

                Debug.Log(data.HealthData.CurrentHealth + " PlayerData/Current Health");
                _player.PlayerHealth.TakeDamage(1);

                _storage.Save();
                
                //после перезагрузки проверить здоровье игрока
            }
        }
    }
}