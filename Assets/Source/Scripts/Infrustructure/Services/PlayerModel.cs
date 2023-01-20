using Money;
using Player;

namespace Assets.Source.Scripts.Infrustructure.Services
{
    public class PlayerModel : IPlayerModel
    {
        private readonly Level _playerParametrs;
        private readonly DamageCalculator _damageCalculator;
        private readonly CostCalculator _costCalculator;
        private readonly SilverWallet _silverWallet;

        public Level Parametrs => _playerParametrs;
        public DamageCalculator DamageCalculator => _damageCalculator;
        public CostCalculator Cost => _costCalculator;
        public SilverWallet SilverWallet => _silverWallet;

        public PlayerModel()
        {
            _playerParametrs = new Level();
            _damageCalculator = new DamageCalculator(_playerParametrs);
            _costCalculator = new CostCalculator(_playerParametrs);
            _silverWallet = new SilverWallet();
        }
    }
}
