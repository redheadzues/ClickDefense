namespace Towers
{
    public class TowerModel
    {
        private Tower _tower;
        private TowerParametrsCalculator _parametrsCalculator;

        public TowerParametrsCalculator TowerCalculatedData => _parametrsCalculator;
        public Tower Tower => _tower;

        public TowerModel(string name, int rank)
        {
            _tower = new Tower(name, rank);
            _parametrsCalculator = new TowerParametrsCalculator(_tower);
        }
    }
}
