using Assets.Source.Scripts.Infrustructure.StaticData;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure.Services.Factories
{
    public interface ICharacterFactory
    {
        GameObject CreateAllie(AllieTypeId typeId);
        GameObject CreateEnemy(EnemyTypeId enemyTypeId);
    }
}