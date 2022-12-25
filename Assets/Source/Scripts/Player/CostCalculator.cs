using NumbersForIdle;
using System;

namespace Player
{
    public class CostCalculator : IPlayerCalculatedData
    {
        private IPlayerData _playerData;

        private const float _baseLevelCostMultiplicator = 1.05f;
        private const float _baseCost = 5;

        public CostCalculator(IPlayerData playerData)
        {
            _playerData = playerData;
        }

        public IdleNumber GetValue()
        {
            IdleNumber currentCost = new(_baseCost * Math.Pow(_baseLevelCostMultiplicator, _playerData.Level));

            return currentCost;
        }
    }
}
