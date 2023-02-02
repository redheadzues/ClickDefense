using Assets.Source.Scripts.Player;
using Money;

namespace Assets.Source.Scripts.Infrustructure.Services.Factories
{
    public interface IUIFactory : IService
    {
        void CreateHud(PlayerModel player, SilverWallet wallet, Vawe vawe);
    }
}