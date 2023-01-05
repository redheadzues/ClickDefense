using NumbersForIdle;
using System;

namespace Player
{
    public class CostCalculator
    {
        private Parametrs _parametrs;

        private const float _baseLevelCostMultiplicator = 1.07f;
        private const float _baseCost = 5;

        public IdleNumber CurrentUpgradePrice => GetValue();

        public CostCalculator(Parametrs parametrs)
        {
            _parametrs = parametrs;
        }

        private IdleNumber GetValue()
        {
            IdleNumber currentCost = new(_baseCost * Math.Pow(_baseLevelCostMultiplicator, _parametrs.Level));

            return currentCost;
        }
    }
}
