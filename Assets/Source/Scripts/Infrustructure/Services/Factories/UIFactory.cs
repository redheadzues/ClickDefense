using Assets.Source.Scripts.Infrustructure.Services.AssetManagment;

namespace Assets.Source.Scripts.Infrustructure.Services.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assetProvider;

        public UIFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public void CreateHud()
        {
            _assetProvider.Instantiate(AssetPath.UIInformation);
        }
    }
}
