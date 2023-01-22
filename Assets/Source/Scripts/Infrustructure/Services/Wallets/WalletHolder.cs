using Assets.Source.Scripts.Infrustructure.Services.SaveLoad;
using Money;

namespace Assets.Source.Scripts.Infrustructure.Services.Wallets
{
    public class WalletHolder : IWalletHolder
    {
        private readonly SilverWallet _silverWallet;

        public SilverWallet SilverWallet => _silverWallet;

        public WalletHolder(ISaveLoadService saveLoad)
        {
            _silverWallet = new SilverWallet(saveLoad);
        }
    }
}