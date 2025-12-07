using JetBrains.Annotations;
using UnityEngine;

namespace Infrastructure.Factory
{
    public interface IMonoBehaviourFactory : IFactoryObject
    {
    }

    public interface IMonoBehaviourFactory<TPrefab, TReturn> : IMonoBehaviourFactory where TPrefab : MonoBehaviour where TReturn : class, IFactoryObject
    {
        TReturn Create(TPrefab prefab, Vector3 position, Quaternion rotation, [CanBeNull] Transform parent = null);
    }
}