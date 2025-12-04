using Infrastructure.SO;
using UnityEngine;

namespace Configs.Weapons
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "Configs/Weapon/WeaponConfig")]

    public class WeaponConfig : ScriptableConfig
    {
        [SerializeField] private int _ammo;
        [SerializeField] private bool _isRanged;
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private  int _cost;
        
        public int Ammo => _ammo;
        public bool IsRanged => _isRanged;
        public string Name => _name;
        public string Description => _description;
        public int Cost => _cost;
    }
}