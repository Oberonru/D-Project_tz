using System.Collections.Generic;
using Items;
using UnityEngine;

namespace Player.Components
{
    public class PlayerInventory : MonoBehaviour
    {
        public List<Item> Inventory =>  _items; 
        [SerializeField] private List<Item> _items = new();

        public void Add(Item item)
        {
            _items.Add(item);
        }

        public void Remove(Item item)
        {
            if (_items.Contains(item)) _items.Remove(item);
        }
    }
}