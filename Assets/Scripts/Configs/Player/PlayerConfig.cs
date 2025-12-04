using Infrastructure.SO;
using UnityEngine;

namespace Configs.Player
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Player/PlayerConfig")]
    public class PlayerConfig : ScriptableConfig
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _lives = 1;
        
        public int MaxHealth => _maxHealth;
        public int Lives => _lives;
    }
}