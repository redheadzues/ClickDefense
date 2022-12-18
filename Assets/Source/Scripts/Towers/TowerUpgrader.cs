public class TowerUpgrader : ITowerUpgrader
{
    private TowerParametrsCalculator _calculator;
    private ITowerData _towerData;
    private ITowerUpgrader _upgrader;
    private IWallet _wallet;

    private TowerUpgrader(Tower tower, IWallet wallet)
    {
        _towerData = tower;
        _upgrader = tower;
        _calculator = new TowerParametrsCalculator(_towerData);
        _wallet = wallet;
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
