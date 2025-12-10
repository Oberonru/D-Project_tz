using Storage;

namespace Items
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }

        protected Item() {}
        
        protected Item(ItemData data)
        {
            Name = data.Name;
            Description = data.Description;
            Cost = data.Cost;
        }
    }
}