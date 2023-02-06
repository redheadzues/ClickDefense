using Assets.Source.Scripts.Player;
using Assets.Source.Scripts.UI;
using Money;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure.Services.Factories
{
    public interface IUIFactory : IService
    {
        void CreateHud(PlayerModel player, SilverWallet wallet, Vawe vawe);
        void CreateRootCanvas();
        GameObject CreateUIElement(string path);
        void CreateWindow(WindowId id);
        TWindow CreateWindow<TWindow>(WindowId id) where TWindow : WindowBase;
    }
}