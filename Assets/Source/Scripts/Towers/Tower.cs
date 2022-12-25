using Saver;

namespace Towers
{
    public class Tower : ITowerData, ITowerUpgrader
    {
        private const float _baseRange = 3;
        private const float _baseAttackRate = 1;
        private const double _baseDamage = 5;
        private const int _baseLevel = 1;
        private const float _baseIncreaserRange = 0.1f;

        private readonly int _rank;
        private string _name;
        private float _range;
        private float _attackRate;
        private double _damage;
        private int _level;

        private SaverTower _saverTower;

        public float Range => _range;

        public float AttackRate => _attackRate;

        public double Damage => _damage;

        public int Level => _level;

        public int Rank => _rank;


        public Tower(string name, int rank)
        {
            _name = name;
            _rank = rank;

            _saverTower = new SaverTower(_name);

            _range = _saverTower.ReadRange(_baseRange);
            _attackRate = _saverTower.ReadAttackRate(_baseAttackRate);
            _damage = _saverTower.ReadDamage(_baseDamage);
            _level = _saverTower.ReadLevel(_baseLevel);
        }

        public void IncreaseRange()
        {
            _range += _baseIncreaserRange;
            _saverTower.WriteRange(_range);
            IncreaseLevel();
        }

        public void IncreaseAttackRate()
        {
            _attackRate += _baseAttackRate;
            _saverTower.WriteRange(_attackRate);
            IncreaseLevel();
        }

        public void IncreaseDamage()
        {
            _damage += _baseDamage;
            _saverTower.WriteDamage(_damage);
            IncreaseLevel();
        }

        private void IncreaseLevel()
        {
            _level++;
            _saverTower.WriteLevel(_level);
        }
    }
}