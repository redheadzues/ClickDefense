using Assets.Source.Scripts.Infrustructure.Services.AssetManagment;
using Assets.Source.Scripts.Infrustructure.Services.ClickListener;
using Assets.Source.Scripts.Infrustructure.Services.Reward;
using Assets.Source.Scripts.Infrustructure.Services.StaticData;
using Assets.Source.Scripts.Infrustructure.StaticData;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure.Services.Factories
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IClickInformer _clickListener;
        private readonly IRewarder _rewarder;
        private readonly IStaticDataService _staticData;

        public EnemyFactory(IAssetProvider assetProvider, IClickInformer clickListener, IRewarder rewarder, IStaticDataService staticData)
        {
            _assetProvider = assetProvider;
            _clickListener = clickListener;
            _rewarder = rewarder;
            _staticData = staticData;
        }

        public GameObject CreateEnemy(Transform parent, EnemyTypeId enemyTypeId)
        {
            //GameObject enemy = _assetProvider.Instantiate(AssetPath.Enemy, parent);
            EnemyStaticData enemyData = _staticData.ForEnemy(enemyTypeId);
            GameObject enemy = Object.Instantiate(enemyData.Prefab, parent);


            if (enemy.TryGetComponent(out ClickReader clickReader))
                _clickListener.Register(clickReader);

            if(enemy.TryGetComponent(out IDamageable damageable))
                _rewarder.RegisterEnemy(damageable);

            return enemy;
        }
    }
}
