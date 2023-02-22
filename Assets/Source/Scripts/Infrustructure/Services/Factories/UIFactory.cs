using Assets.Source.Scripts.GameOver;
using Assets.Source.Scripts.Infrustructure.Services.AssetManagment;
using Assets.Source.Scripts.Infrustructure.Services.StaticData;
using Assets.Source.Scripts.Player;
using Assets.Source.Scripts.UI.Windows;
using Money;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure.Services.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticData;

        private Transform _rootCanvas;

        public UIFactory(IAssetProvider assetProvider, IStaticDataService staticData)
        {
            _assetProvider = assetProvider;
            _staticData = staticData;
        }

        public void CreateWindow(WindowId id) =>
            Object.Instantiate(_staticData.ForWindow(id), _rootCanvas);

        public GameObject CreateUIElement(string path) =>
            _assetProvider.Instantiate(path);

        public void CreateRootCanvas() =>
            _rootCanvas = _assetProvider.Instantiate(AssetPath.RootCanvas).transform;
        
        public TWindow CreateWindow<TWindow>(WindowId id) where TWindow : WindowBase
        {
            WindowBase windowPrefab = _staticData.ForWindow(id);
            var window =  Object.Instantiate(windowPrefab, _rootCanvas);
            
            TWindow? tWindow = window as TWindow;            
            
            return tWindow;
        }

        public void CreateHud(PlayerModel player, SilverWallet wallet, Vawe vawe, ICharacterFactory characterFactory, LivesCounter counter)
        {
            GameObject hud = _assetProvider.Instantiate(AssetPath.Hud, _rootCanvas);

            hud.GetComponent<UIHud>().Construct(player, wallet, vawe, counter);
            hud.GetComponent<UIButtonNextVawe>().Construct(vawe);
            hud.GetComponent<ButtonAddCharacter>().Construct(characterFactory);

        }
    }
}
