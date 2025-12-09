using System;
using Configs.Player;
using HealthSystem.Model;
using Services;
using Storage;
using UnityEngine;
using Zenject;

namespace Player.Components
{
    [RequireComponent(typeof(PlayerInstance))]
    public class PlayerDataComponent : MonoBehaviour
    {
        [Inject] private PlayerConfig _config;
        [Inject] private StorageService _storage;
        [SerializeField] private PlayerInstance _player;

        public PlayerData Data => _data;
        private PlayerData _data;

        private void Awake()
        {
            LoadPlayerData();
        }

        private void OnEnable()
        {
            _player.PlayerHealth.OnHealthChanged += HandleHealthChanged;
        }

        private void OnValidate()
        {
            if (_player == null) _player = GetComponent<PlayerInstance>();
        }

        private void HandleHealthChanged(int current, int max)
        {
            _data.HealthData.CurrentHealth = current;
            _data.HealthData.MaxHealth = max;
        }

        private void OnDisable()
        {
            _player.PlayerHealth.OnHealthChanged -= HandleHealthChanged;
        }

        private async void LoadPlayerData()
        {
            try
            {
                _data = await _storage.Load();

                if (BeginGame())
                {
                    InitStartingData();
                }

                else
                {
                    LoadingData();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void LoadingData()
        {
            _player.PlayerHealth.MaxHealth = _player.PlayerData.Data.HealthData.MaxHealth;
            _player.PlayerHealth.CurrentHealth = _player.PlayerData.Data.HealthData.CurrentHealth;
            
            //Загрузка экипировки
            //Загрузка инвентаря
        }

        private void InitStartingData()
        {
            foreach (var i in _config.StartItems)
            {
                var item = i.CreateItem();
                _player.PlayerInventory.Add(item);
            }

            var health = new Health(_config.MaxHealth);
            _player.PlayerHealth.Init(health);

            HandleHealthChanged(health.CurrentHealth, health.MaxHealth);
        }

        private bool BeginGame()
        {
            return _data.HealthData.MaxHealth <= 0;
        }
    }
}