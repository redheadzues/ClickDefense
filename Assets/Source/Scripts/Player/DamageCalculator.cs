using System;
using NumbersForIdle;

namespace Player
{
    public class DamageCalculator : IPlayerDamage
    {
        private const int _percent = 100;

        private IPlayerData _playerData;
        private int _levelMultiplicator = 1;

        public DamageCalculator(IPlayerData playerData, IDataChangedNotifyer notyfier)
        {
            _playerData = playerData;
            notyfier.DataChanged += OnDataChanged;
        }

        public IdleNumber GetPureValue()
        {
            IdleNumber damage = new(_playerData.Level * _levelMultiplicator);

            return damage;
        }

        public IdleNumber GetValue()
        {
            IdleNumber damage = GetPureValue() * GetCriticalStrike();

            return damage;
        }

        private float GetCriticalStrike()
        {
            if (_playerData.CriticalChance >= RandomFloat.Next(0, _percent))
                return _playerData.CriticalMultiplicator;
            else
                return 1;
        }

        private void OnDataChanged()
        {
            _levelMultiplicator = LevelIncreaseDamage();
        }

        private int LevelIncreaseDamage()
        {
            int increaser = EveryHundredLevelIncreaseDamage() + EveryTwoHundredLevelIncreaseDamage() + Every25LevelIncreaser();

            return increaser;
        }

        private int EveryHundredLevelIncreaseDamage()
        {
            int increaser = _playerData.Level / 100;
            increaser *= 3;
            increaser = Math.Clamp(increaser, 1, increaser);

            return increaser;
        }

        private int EveryTwoHundredLevelIncreaseDamage()
        {
            int increaser = _playerData.Level / 200;
            increaser *= 6;

            return increaser;
        }

        private int Every25LevelIncreaser()
        {
            int increaser = 0;

            if (_playerData.Level >= 250)
                increaser = _playerData.Level / 25;

            increaser *= 4;

            return increaser;
        }
    }
}
