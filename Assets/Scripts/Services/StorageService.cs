using System;
using System.IO;
using Cysharp.Threading.Tasks;
using Infrastructure.SO;
using Storage;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;
using Zenject;

namespace Services
{
    [CreateAssetMenu(fileName = "StorageService", menuName = "Services/StorageService")]
    public sealed class StorageService : ScriptableService, IInitializable
    {
        [field: NonSerialized] public PlayerData PlayerData { get; protected set; }

        [SerializeField] private string _fileName = "player.json";
        [SerializeField] private string _folderName = "LocalSave";
        public event Action OnLoaded;

        private string _filePath;

        public void Initialize()
        {
            _filePath = Path.Combine(Application.persistentDataPath, _folderName, _fileName);
            var dir = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(dir))
                Directory.CreateDirectory(dir);
        }

        public bool IsLoaded() => PlayerData != null;

        public void Save()
        {
            if (!IsReady()) return;


            if (PlayerData == null)
            {
                Debug.LogWarning("Save called with null PlayerData.");
                return;
            }

            try
            {
                var json = JsonConvert.SerializeObject(PlayerData, Formatting.Indented);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to save PlayerData: {e.Message}");
            }
        }

        public async UniTask<PlayerData> Load()
        {
            if (!IsReady())
            {
                Debug.LogWarning("SaveLoadService not initialized yet. Returning new PlayerData.");
                PlayerData = new PlayerData();
                OnLoaded?.Invoke();
                return PlayerData;
            }

            if (!File.Exists(_filePath))
            {
                PlayerData = new PlayerData();
                OnLoaded?.Invoke();

                return PlayerData;
            }

            try
            {
                var json = await File.ReadAllTextAsync(_filePath);
                PlayerData = JsonConvert.DeserializeObject<PlayerData>(json) ?? new PlayerData();

                OnLoaded?.Invoke();
                return PlayerData;
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load PlayerData: {e.Message}");
                PlayerData = new PlayerData();
                OnLoaded?.Invoke();

                return PlayerData;
            }
        }
        
        public void Clear()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    File.Delete(_filePath);
                    Debug.Log("Хранилище очищено: файл сохранения удалён.");
                }
                else
                {
                    Debug.Log("Хранилище уже пустое.");
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"Ошибка очистки: {e}");
            }
        }

        private bool IsReady()
        {
            if (string.IsNullOrEmpty(_filePath))
            {
                Debug.LogWarning("SaveLoadService _filePath is not set. Did Initialize run?");
                return false;
            }

            return true;
        }
    }
}