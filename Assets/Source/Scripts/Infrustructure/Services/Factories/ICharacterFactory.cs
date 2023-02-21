using Assets.Source.Scripts.Infrustructure.StaticData;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure.Services.Factories
{
    public interface ICharacterFactory
    {
        GameObject CreateEnemy(Transform parent, EnemyTypeId enemyTypeId);
    }
}