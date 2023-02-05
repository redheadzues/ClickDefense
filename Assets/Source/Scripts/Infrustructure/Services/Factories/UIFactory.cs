using Assets.Source.Scripts.Infrustructure.Services.AssetManagment;
using Assets.Source.Scripts.Player;
using Money;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure.Services.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assetProvider;
        private Transform _rootCanvas;

        public UIFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public void CreateHud(PlayerModel player, SilverWallet wallet, Vawe vawe)
        {
            GameObject hud = _assetProvider.Instantiate(AssetPath.Hud, _rootCanvas);

            hud.GetComponent<UIHud>().Construct(player, wallet, vawe);
            hud.GetComponent<UIButtonNextVawe>().Construct(vawe);

        }

        public void CreateRootCanvas()
        {
            _rootCanvas = _assetProvider.Instantiate(AssetPath.RootCanvas).transform;
        }
    }
}
