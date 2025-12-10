using System;
using Configs.Player;
using HealthSystem.Model;
using Items;
using Items.Instances;
using Services;
using Storage;
using UnityEngine;
using WeaponSystem.Model;
using Zenject;

namespace Player.Components
{
    [RequireComponent(typeof(PlayerInstance))]
    public class PlayerDataComponent : MonoBehaviour
    {
        [Inject] private PlayerConfig _config;
        [Inject] private StorageService _storage;
        [Inject] private DiContainer _di;
        [SerializeField] private PlayerInstance _player;

        public PlayerData Data => _data;
        private PlayerData _data;

        private void Awake()
        {
            LoadPlayerData();
        }

        private void OnEnable()
        {
            if (_player?.PlayerHealth != null)
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
            var health = new Health(_data.HealthData.MaxHealth)
            {
                CurrentHealth = Mathf.Clamp(_data.HealthData.CurrentHealth, 0, _data.HealthData.MaxHealth)
            };

            _player.PlayerHealth.Init(health);

            HandleHealthChanged(health.CurrentHealth, health.MaxHealth);
            //Загрузка инвентаря

            foreach (var itemData in _player.PlayerData.Data.InventoryData.ItemsData)
            {
                Item item = null;

                switch (itemData.ItemTypeData)
                {
                    case ItemTypeData.Weapon:
                        item = _di.Instantiate<Weapon>(new[] { itemData });
                        break;
                    case ItemTypeData.Until:
                        item = _di.Instantiate<UntilItem>(new[] { itemData });
                        break;
                    case ItemTypeData.RocketPack:
                        item = _di.Instantiate<RocketPack>(new[] { itemData });
                        break;
                }

                if (item != null)
                {
                    _player.PlayerInventory.Add(item);
                }
            }

            //Экипировка игрока
            if (_data.EquipmentData.PrimaryWeaponSlot != null)
            {
                var weapon = _di.Instantiate<Weapon>(new object[] { _data.EquipmentData.PrimaryWeaponSlot });
                _player.Equipment.Equip(weapon);
            }
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