using System;
using UnityEngine;

namespace Assets.Source.Scripts.Enemies
{
    public class EnemyHealth : MonoBehaviour, IDamageable, IHealth
    {
        private int _value;
        private int _currentValue;

        public int Health => _currentValue;
        public event Action<int> HealthChanged;

        public void ResetCurrentValue()
        {
            _currentValue = _value;
            HealthChanged?.Invoke(_currentValue);
        }

        public void SetNewValue(int value)
        {
            _value = value;
            ResetCurrentValue();
        }

        public void TakeDamage(int damage)
        {
            if (damage > 0)
            {
                _currentValue -= damage;
                HealthChanged?.Invoke(_currentValue);
            }
        }
    }
}