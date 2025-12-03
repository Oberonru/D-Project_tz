using HealthSystem;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(HealthComponent))]
    public class PlayerInstance : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;

        public HealthComponent PlayerHealth => _healthComponent;

        private void OnValidate()
        {
            if (_healthComponent == null) _healthComponent = GetComponent<HealthComponent>();
        }
    }
}