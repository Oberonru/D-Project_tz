using Infrastructure.SO;
using UnityEngine;

namespace Configs.Input
{
    [CreateAssetMenu(fileName = "KeyConfig", menuName = "Configs/Player/KeyConfig")]
    public class KeyConfig : ScriptableConfig
    {
        [SerializeField] private KeyCode _checkInventoryKey = KeyCode.I;
        [SerializeField] private KeyCode _checkPlayerHealth = KeyCode.H;
        [SerializeField] private KeyCode _checkPlayerAttack = KeyCode.Space;
        [SerializeField] private KeyCode _checkSave = KeyCode.S;

        public KeyCode CheckInventoryKey => _checkInventoryKey;
        public KeyCode CheckPlayerHealth => _checkPlayerHealth;
        public KeyCode CheckPlayerAttack => _checkPlayerAttack;
        public KeyCode CheckSave => _checkSave;
    }
}