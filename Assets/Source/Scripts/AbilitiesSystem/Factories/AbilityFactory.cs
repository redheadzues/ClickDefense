using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using Assets.Source.Scripts.Infrustructure;
using Assets.Source.Scripts.Infrustructure.Services.StaticData;

namespace Assets.Source.Scripts.AbilitiesSystem.Factories
{
    public class AbilityFactory : IAbilityFactory
    {
        private readonly IStaticDataService _staticData;
        private readonly ICoroutineRunner _coroutineRunner;

        public AbilityFactory(IStaticDataService staticData, ICoroutineRunner coroutineRunner)
        {
            _staticData = staticData;
            _coroutineRunner = coroutineRunner;
        }

        public Ability CreateAbility(string name)
        {
            AbilityStaticData abilityData = _staticData.ForAbility(name);

            switch (abilityData.TargetDetermineTypeId)
            {
                case AbilityTargetDetermineTypeId.Single:
                    return new SingleAbility(abilityData);
                case AbilityTargetDetermineTypeId.Area:
                    return new AreaAbility(abilityData);
                case AbilityTargetDetermineTypeId.Chain:
                    return new ChainAbility(abilityData, _coroutineRunner);
            }

            return null;
        }
    }
}
