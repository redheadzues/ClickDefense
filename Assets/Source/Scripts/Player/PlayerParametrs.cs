using Saver;

namespace Player
{
    public class PlayerParametrs : IPlayerData, IPlayerUpgrader
    {
        private const int _defaultLevel = 1;
        private const int _defaultDamage = 1;
        private const float _defaultCriticalChance = 0.5f;
        private const float _defaultCriticalMultiplicator = 1.5f;

        private int _level;
        private int _damage;
        private float _criticalChance;
        private float _criticalMultiplicator;
        private SaverPlayerParametrs _saver;

        public int Level => _level;
        public int Damage => _damage;
        public float CriticalChance => _criticalChance; 
        public float CriticalMultiplicator => _criticalMultiplicator;

        public PlayerParametrs()
        {
            _level = _saver.ReadLevel(_defaultLevel);
            _damage = _saver.ReadDaamge(_defaultDamage);
            _criticalChance = _saver.ReadCriticalChance(_defaultCriticalChance);
            _criticalMultiplicator = _saver.ReadCriticalMultiplicator(_defaultCriticalMultiplicator);
        }

        public void IncreaseLevel()
        {
            _level++;
            _saver.WriteLevel(_level);
        }

        public void IncreaseCriticalChance(float value)
        {
            _criticalChance += value;
            _saver.WriteCriticalChance(_criticalChance);
        }

        public void IncreaseCriticalMultiplicator(float value)
        {
            _criticalMultiplicator += value;
            _saver.WriteCriticalMultiplicator(_criticalMultiplicator);
        }
    }
}