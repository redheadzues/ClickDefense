using NumbersForIdle;
using Player;

namespace Assets.Source.Scripts.Infrustructure.Services
{
    public class PlayerModel : IPlayerModel
    {
        private readonly Parametrs _playerParametrs;
        private readonly DamageCalculator _damageCalculator;
        private readonly CostCalculator _costCalculator;

        public Parametrs Parametrs => _playerParametrs;
        public IdleNumber Cost => _costCalculator.CurrentUpgradePrice;
        public IdleNumber Damage => _damageCalculator.GetValue();

        public PlayerModel()
        {
            _playerParametrs = new Parametrs();
            _damageCalculator = new DamageCalculator(_playerParametrs);
            _costCalculator = new CostCalculator(_playerParametrs);

            _playerParametrs.LoadSaves();
        }
    }
}
