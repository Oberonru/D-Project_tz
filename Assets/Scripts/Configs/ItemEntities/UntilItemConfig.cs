using Items;
using Items.Instances;
using UnityEngine;

namespace Configs.ItemEntities
{
    [CreateAssetMenu(fileName = "UntilItemConfig", menuName = "Configs/UntilItem/UntilItemConfig")]
    public class UntilItemConfig : ItemConfig
    {
        public override Item CreateItem()
        {
            return new UntilItem(Name, Description, Cost);
        }
    }
}