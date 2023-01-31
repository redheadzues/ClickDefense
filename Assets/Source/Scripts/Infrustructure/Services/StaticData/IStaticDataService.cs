using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using Assets.Source.Scripts.Infrustructure.StaticData;

namespace Assets.Source.Scripts.Infrustructure.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void Load();
        EnemyStaticData ForEnemy(EnemyTypeId typeId);
        SceneStaticData ForLevel();
        AbilityStaticData ForAbility(string name);
    }
}