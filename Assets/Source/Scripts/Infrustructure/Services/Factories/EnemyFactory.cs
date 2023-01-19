using Assets.Source.Scripts.Infrustructure.Services.AssetManagment;
using Assets.Source.Scripts.Infrustructure.Services.ClickListener;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure.Services.Factories
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IClickListener _clickListener;

        public EnemyFactory(IAssetProvider assetProvider, IClickListener clickListener)
        {
            _assetProvider = assetProvider;
            _clickListener = clickListener;
        }

        public GameObject CreateEnemy(Transform parent)
        {
            GameObject enemy = _assetProvider.Instantiate(AssetPath.Enemy, parent);

            if (enemy.TryGetComponent(out ClickReader clickReader))
                _clickListener.Register(clickReader);

            return enemy;
        }
    }
}
