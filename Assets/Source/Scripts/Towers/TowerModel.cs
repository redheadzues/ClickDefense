namespace Towers
{
    public class TowerModel
    {
        private Tower _tower;
        private TowerUpgrader _upgrader;
        private TowerParametrsCalculator _parametrsCalculator;

        public ITowerCalculatedData TowerCalculatedData => _parametrsCalculator;
        public ITowerUpgrader TowerUpgrader => _upgrader;

        public TowerModel(string name, int rank, IWallet wallet)
        {
            _tower = new Tower(name, rank);
            _parametrsCalculator = new TowerParametrsCalculator(_tower);
            _upgrader = new TowerUpgrader(_tower, wallet, _parametrsCalculator);
        }
    }
}
