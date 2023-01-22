using Assets.Source.Scripts.Enemies;
using Assets.Source.Scripts.Infrustructure.Services.ClickListener;
using Assets.Source.Scripts.Infrustructure.Services.Reward;
using Assets.Source.Scripts.Infrustructure.Services.StaticData;
using Assets.Source.Scripts.Infrustructure.StaticData;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Source.Scripts.Infrustructure.Services.Factories
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IClickInformer _clickListener;
        private readonly IRewarder _rewarder;
        private readonly IStaticDataService _staticData;

        public EnemyFactory(IClickInformer clickListener, IRewarder rewarder, IStaticDataService staticData)
        {
            _clickListener = clickListener;
            _rewarder = rewarder;
            _staticData = staticData;
        }

        public GameObject CreateEnemy(Transform parent, EnemyTypeId enemyTypeId)
        {
            EnemyStaticData enemyData = _staticData.ForEnemy(enemyTypeId);
            GameObject enemy = Object.Instantiate(enemyData.Prefab, parent);

            SetupEnemy(enemyData, enemy);
            RegisterEnemy(enemy);

            return enemy;
        }

        private static void SetupEnemy(EnemyStaticData enemyData, GameObject enemy)
        {
            enemy.GetComponent<EnemyHealth>().SetNewValue(enemyData.HP);
            enemy.GetComponent<IEnemy>().Reward = enemyData.Reward;
            enemy.GetComponent<NavMeshAgent>().speed = enemyData.Speed;
        }

        private void RegisterEnemy(GameObject enemy)
        {
            _clickListener.Register(enemy.GetComponent<ClickReader>());
            _rewarder.Register(enemy.GetComponent<IEnemy>());
        }
    }
}
