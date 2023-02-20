using System;
using UnityEngine;

namespace Assets.Source.Scripts.CharactersComponent
{
    public class Death : MonoBehaviour
    {
        [SerializeField] private Health _health;

        public event Action Happend;

        private void OnEnable()
        {
            _health.HealthChanged += OnValueChanged;
        }

        private void OnDisable()
        {
            _health.HealthChanged -= OnValueChanged;
        }

        private void OnValueChanged(int health)
        {
            if (health < 1)
                Die();
        }

        private void Die()
        {
            Happend?.Invoke();
            gameObject.SetActive(false);
        }
    }
}