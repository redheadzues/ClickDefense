namespace Player
{
    public class PlayerModel
    {
        private Wallet _wallet;
        private PlayerLevel _playerLevel;

        public IWallet Wallet => _wallet;

        public PlayerModel()
        {
            _wallet = new Wallet();
            _playerLevel = new PlayerLevel();
        }
    }

}