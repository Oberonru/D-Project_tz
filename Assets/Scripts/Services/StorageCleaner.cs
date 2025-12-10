using UnityEngine;
using Zenject;

namespace Services
{
    public class StorageCleaner : MonoBehaviour
    {
        [Inject] private StorageService _storage;

        [ContextMenu("Clean Player Data")]
        public void CleanPlayerData()
        {
            _storage.Clear();
        }
    }
}