using NumbersForIdle;
using System;

namespace Shops
{
    public class ShopPlayer
    {
        private IWallet _wallet;
        private IPlayerUpgrader _playerUpgrader;
        private IPlayerCalculatedCost _cost;

        public string Price => _cost.GetValue().ToString();

        public ShopPlayer(IWallet wallet, IPlayerUpgrader upgrader, IPlayerCalculatedCost cost)
        {
            _wallet = wallet;
            _playerUpgrader = upgrader; 
            _cost = cost;
        }

        public bool IncreaseLevel()
        {
            if (_wallet.TrySpendMoney(_cost.GetValue()))
            {
                _playerUpgrader.IncreaseLevel();
                return true;
            }
            else
                return false;
        }
    }
}


