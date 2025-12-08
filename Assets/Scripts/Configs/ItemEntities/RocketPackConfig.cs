using Items;
using Items.Instances;
using UnityEngine;

namespace Configs.ItemEntities
{
    [CreateAssetMenu(fileName = "RocketPackConfig", menuName = "Configs/ItemEntities/RocketPackConfig")]
    public class RocketPackConfig : ItemConfig
    {
        [SerializeField] private int _charge;

        public int Charge => _charge;

        public override Item CreateItem()
        {
            return new RocketPack(Name, Description, Cost, _charge);
        }
    }
}