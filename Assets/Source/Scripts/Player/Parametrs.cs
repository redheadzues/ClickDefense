using Saver;
using System;

namespace Player
{
    public class Parametrs : IPlayerData, IPlayerUpgrader, IDataChangedNotifyer
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

        public event Action DataChanged;

        public int Level => _level;
        public int Damage => _damage;
        public float CriticalChance => _criticalChance; 
        public float CriticalMultiplicator => _criticalMultiplicator;

        public Parametrs()
        {
            _saver = new SaverPlayerParametrs();
            _level = _saver.ReadLevel(_defaultLevel);
            _damage = _saver.ReadDaamge(_defaultDamage);
            _criticalChance = _saver.ReadCriticalChance(_defaultCriticalChance);
            _criticalMultiplicator = _saver.ReadCriticalMultiplicator(_defaultCriticalMultiplicator);
        }

        public void IncreaseLevel()
        {
            _level++;
            _saver.WriteLevel(_level);
            NotifyAboutChange();
        }

        public void IncreaseCriticalChance(float value)
        {
            _criticalChance += value;
            _saver.WriteCriticalChance(_criticalChance);
            NotifyAboutChange();
        }

        public void IncreaseCriticalMultiplicator(float value)
        {
            _criticalMultiplicator += value;
            _saver.WriteCriticalMultiplicator(_criticalMultiplicator);
            NotifyAboutChange();
        }

        private void NotifyAboutChange()
        {
            DataChanged?.Invoke();
        }
    }
}