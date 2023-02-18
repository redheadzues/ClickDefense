using Assets.Source.Scripts.CharactersComponent;
using Assets.Source.Scripts.Infrustructure.StaticData;
using System;
using UnityEngine;

namespace Assets.Source.Scripts.Enemies
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        [SerializeField] private Health _health;
        [SerializeField] private EnemyDeath _death;

        public Transform TargetPoint;
        public Vector3 Position => transform.position;
        public int Value => _health.Value;
        public int Reward { get; set; }
        public EnemyTypeId TypeId { get; set; }
        public event Action<IEnemy> Died;
        public event Action<int> HealthChanged;

        private void OnEnable()
        {
            _health.HealthChanged += OnHealthChanged;
            _death.Happend += OnDeathHappend;
        }

        private void OnDisable()
        {
            _health.HealthChanged -= OnHealthChanged;
            _death.Happend -= OnDeathHappend;
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }

        private void OnDeathHappend()
        {
            Died?.Invoke(this);
        }

        private void OnHealthChanged(int value)
        {
            HealthChanged?.Invoke(value);
        }
    }
}