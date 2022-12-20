using System;
using NumbersForIdle;

namespace Player
{
    public class PlayerDamageCalculator
    {
        private const int _percent = 100;

        private IPlayerData _playerData;
        private Random _random;

        public PlayerDamageCalculator(IPlayerData playerData)
        {
            _playerData = playerData;
            _random = new Random();
        }

        public IdleNumber GetValue()
        {
            return new IdleNumber(5);
        }

        private bool CheckCriticalStrike()
        {
            return _playerData.CriticalChance >= (float)_random.Next(0, _percent);
        }
    }
}
