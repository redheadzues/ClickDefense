using System;
using UnityEngine;

namespace Assets.Source.Scripts.Enemies
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        [SerializeField] private EnemyHealth _health;
        [SerializeField] private EnemyDeath _death;

        public Vector3 Position => transform.position;
        public int Health => _health.Health;
        public int Reward { get; set; }
        public event Action<IEnemy> Died;
        public event Action<int> HealthChanged;

        private void OnEnable()
        {
            _health.HealthChanged += HealthChanged;
            _death.Happend += OnDeathHappend;
        }
        private void OnDestroy()
        {
            _health.HealthChanged -= HealthChanged;
            _death.Happend -= OnDeathHappend;
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }

        private void OnDeathHappend()
        {
            Died?.Invoke(this);
            gameObject.SetActive(false);
        }
    }
}