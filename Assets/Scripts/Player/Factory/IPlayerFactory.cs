using Infrastructure.Factory;

namespace Player.Factory
{
    public interface IPlayerFactory : IMonoBehaviourFactory<PlayerInstance, IPlayerInstance>
    {
    }
}