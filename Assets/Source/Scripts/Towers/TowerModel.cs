namespace Towers
{
    public class TowerModel
    {
        private Tower _tower;
        private TowerParametrsCalculator _parametrsCalculator;

        public ITowerCalculatedData TowerCalculatedData => _parametrsCalculator;
        public ITowerUpgrader TowerUpgrader => _tower;
        public ITowerData TowerData => _tower;

        public TowerModel(string name, int rank)
        {
            _tower = new Tower(name, rank);
            _parametrsCalculator = new TowerParametrsCalculator(_tower);
        }
    }
}
