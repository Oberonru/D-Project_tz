namespace Items.Instances
{
    public class RocketPack : Item
    {
        private int _charge;

        public RocketPack(string name, string description, int cost, int charge)
        {
            Name = name;
            Description = description;
            Cost = cost;
            _charge = charge;
        }
    }
}