using Assets.Source.Scripts.Infrustructure.StaticData;

namespace Assets.Source.Scripts.Infrustructure.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        EnemyStaticData ForEnemy(EnemyTypeId typeId);
        SceneStaticData ForLevel();
        void Load();
    }
}