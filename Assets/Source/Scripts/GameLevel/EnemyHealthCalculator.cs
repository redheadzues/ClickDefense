using NumbersForIdle;
using System;

namespace GameLevel
{
    public class EnemyHealthCalculator
    {
        private Level _level;

        private float _healthMultiplicator;
        private float _baseHealth;

        public EnemyHealthCalculator(Level level, float healthMultiplicator = 1.5f, float baseHealth = 10f)
        {
            _level = level;
            _healthMultiplicator = healthMultiplicator;
            _baseHealth = baseHealth;
        }

        public IdleNumber GetValue()
        {
            IdleNumber health = new(_baseHealth * Math.Pow(_healthMultiplicator, _level.Value));

            return health;
        }
    }
}