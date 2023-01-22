using Assets.Source.Scripts.Infrustructure.StaticData;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure.Services.Factories
{
    public interface IEnemyFactory : IService
    {
        GameObject CreateEnemy(Transform parent, EnemyTypeId enemyTypeId);
    }
}