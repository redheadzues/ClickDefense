namespace Player
{
    public class PlayerModel
    {
        private Wallet _wallet;

        public IWallet Wallet => _wallet;

        public PlayerModel()
        {
            _wallet = new Wallet();
        }
    }

}