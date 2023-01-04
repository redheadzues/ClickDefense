using System;
using NumbersForIdle;

namespace Player
{
    public class DamageCalculator
    {
        private const int _percent = 100;

        private Parametrs _parametrs;
        private int _levelMultiplicator = 1;

        public DamageCalculator(Parametrs parametrs)
        {
            _parametrs = parametrs;
            _parametrs.DataChanged += OnDataChanged;
        }

        public IdleNumber GetPureValue()
        {
            IdleNumber damage = new(_parametrs.Level * _levelMultiplicator);

            return damage;
        }

        public IdleNumber GetValue()
        {
            IdleNumber damage = GetPureValue() * GetCriticalStrike();

            return damage;
        }

        private float GetCriticalStrike()
        {
            if (_parametrs.CriticalChance >= RandomFloat.Next(0, _percent))
                return _parametrs.CriticalMultiplicator;
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
            int increaser = _parametrs.Level / 100;
            increaser *= 3;
            increaser = Math.Clamp(increaser, 1, increaser);

            return increaser;
        }

        private int EveryTwoHundredLevelIncreaseDamage()
        {
            int increaser = _parametrs.Level / 200;
            increaser *= 6;

            return increaser;
        }

        private int Every25LevelIncreaser()
        {
            int increaser = 0;

            if (_parametrs.Level >= 250)
                increaser = _parametrs.Level / 25;

            increaser *= 4;

            return increaser;
        }
    }
}
