using Assets.Source.Scripts.Player;

namespace Assets.Source.Scripts.Infrustructure.Services.Factories
{
    public interface IUIFactory : IService
    {
        void CreateHud(PlayerModel player, Vawe vawe);
    }
}