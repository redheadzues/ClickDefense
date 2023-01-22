using System;
using UnityEngine;

namespace Assets.Source.Scripts.Enemies
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _health;

        public Action Happend;

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