using Infrastructure.SO;
using Items;
using UnityEngine;

namespace Configs.ItemData
{
    public abstract class ItemConfig : ScriptableConfig
    {
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private int _cost;
        [SerializeField] private ItemType _itemType;
        
        public string Name => _name;
        public string Description => _description;
        public int Cost => _cost;
        public ItemType ItemType => _itemType;

        public abstract Item CreateItem();
    }
}