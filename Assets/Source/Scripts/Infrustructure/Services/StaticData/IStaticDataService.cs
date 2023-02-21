using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using Assets.Source.Scripts.AbilitiesSystem.Tree;
using Assets.Source.Scripts.Infrustructure.StaticData;
using Assets.Source.Scripts.UI;

namespace Assets.Source.Scripts.Infrustructure.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void Load();
        EnemyStaticData ForEnemy(EnemyTypeId typeId);
        AllieStaticData ForAllie(AllieTypeId typeId);
        SceneStaticData ForLevel();
        AbilityStaticData ForAbility(string id);
        Branch ForPlayerAbility();
        WindowBase ForWindow(WindowId id);
    }
}