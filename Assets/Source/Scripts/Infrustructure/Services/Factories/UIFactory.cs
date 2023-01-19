using Assets.Source.Scripts.Infrustructure.Services.AssetManagment;
using Assets.Source.Scripts.Infrustructure.Services.ClickListener;
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

        public void CreateHud()
        {
            _assetProvider.Instantiate(AssetPath.UIInformation);
        }
    }

    public class EnemyFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IClickListener _clickListener;

        public EnemyFactory(IAssetProvider assetProvider, IClickListener clickListener)
        {
            _assetProvider = assetProvider;
            _clickListener = clickListener;
        }

        public void CreateEnemy()
        {
            GameObject enemy = _assetProvider.Instantiate(AssetPath.Enemy);
            
            if(enemy.TryGetComponent(out ClickReader clickReader))
                _clickListener.Register(clickReader);
        }
    }
}
