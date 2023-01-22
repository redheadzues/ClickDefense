using Money;

namespace Assets.Source.Scripts.Infrustructure.Services.Wallets
{
    public interface IWalletHolder : IService
    {
        SilverWallet SilverWallet { get; }
    }
}