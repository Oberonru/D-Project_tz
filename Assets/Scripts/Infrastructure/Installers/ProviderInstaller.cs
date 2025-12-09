using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class ProviderInstaller<T> : MonoInstaller where T : ScriptableObject
    {
        public T[] _elements = new T[0];

        public override void InstallBindings()
        {
            for (var i = 0; i < _elements.Length; i++)
            {
                var element = _elements[i];
                Container.Bind(element.GetType()).FromInstance(element).AsSingle();

                if (element is IInitializable initializable)
                {
                    initializable.Initialize();
                }
             }
        }
    }
}