using Assets.Source.Scripts.Infrustructure.Services.AssetManagment;
using Assets.Source.Scripts.Player;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure.Services.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assetProvider;

        public UIFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public void CreateHud(PlayerModel player, Vawe vawe)
        {
            GameObject hud = _assetProvider.Instantiate(AssetPath.Hud);

            hud.GetComponentInChildren<UIHud>().Construct(player);
            hud.GetComponent<UIButtonNextVawe>().Construct(vawe);

        }
    }
}
