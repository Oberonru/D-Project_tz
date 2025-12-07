using UnityEngine;
using Zenject;

namespace Player.Factory
{
    public class PlayerFactory : IPlayerFactory
    {
        [Inject] private DiContainer _diContainer;
        
        public IPlayerInstance Create(PlayerInstance prefab, Vector3 position, Quaternion rotation, Transform parent = null)
        {
            var player = _diContainer.InstantiatePrefabForComponent<PlayerInstance>(prefab, position, rotation, parent);
            
            return player;
        }
    }
}