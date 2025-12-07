using System.Collections.Generic;
using Configs.ItemData;
using Infrastructure.SO;
using UnityEngine;

namespace Configs.Player
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Player/PlayerConfig")]
    public class PlayerConfig : ScriptableConfig
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _lives = 1;
        [SerializeField] private List<ItemConfig>  _startItems;
        
        public int MaxHealth => _maxHealth;
        public int Lives => _lives;
        public List<ItemConfig> StartItems => _startItems;
    }
}