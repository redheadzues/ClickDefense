namespace Player
{
    public class PlayerModel
    {
        private Wallet _wallet;
        private Parametrs _playerParametrs;
        private DamageCalculator _damageCalculator;
        private CostCalculator _costCalculator;

        public IWallet Wallet => _wallet;
        public IDataChangedNotifyer Parametrs => _playerParametrs;
        public IPlayerCalculatedData Damage => _damageCalculator;
        public IPlayerCalculatedData Cost => _costCalculator;

        public PlayerModel()
        {
            _wallet = new Wallet();
            _playerParametrs = new Parametrs();
            _damageCalculator = new DamageCalculator(_playerParametrs, _playerParametrs);
            _costCalculator = new CostCalculator(_playerParametrs);
        }
    }
}