using Assets.Source.Scripts.Infrustructure.Services.AssetManagment;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure.Services.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IPlayerModel _player;

        public UIFactory(IAssetProvider assetProvider, IPlayerModel player)
        {
            _assetProvider = assetProvider;
            _player = player;
        }

        public void CreateHud()
        {
            GameObject hud = _assetProvider.Instantiate(AssetPath.Hud);

            hud.GetComponentInChildren<UIHud>().Construct(_player);

        }
    }
}
