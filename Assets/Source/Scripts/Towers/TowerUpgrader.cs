namespace Towers
{
    public class TowerUpgrader : ITowerUpgrader
    {
        private ITowerUpgrader _upgrader;
        private IWallet _wallet;
        private ITowerCalculatedData _calculator;

        public TowerUpgrader(ITowerUpgrader tower, IWallet wallet, ITowerCalculatedData calculator)
        {
            _upgrader = tower;
            _wallet = wallet;
            _calculator = calculator;
        }

        public void IncreaseAttackRate()
        {
            if (_wallet.TrySpendMoney(_calculator.CurrentUpgradeCost))
                _upgrader.IncreaseAttackRate();
        }

        public void IncreaseDamage()
        {
            if (_wallet.TrySpendMoney(_calculator.CurrentUpgradeCost))
                _upgrader.IncreaseDamage();
        }

        public void IncreaseRange()
        {
            if (_wallet.TrySpendMoney(_calculator.CurrentUpgradeCost))
                _upgrader.IncreaseRange();
        }
    }
}