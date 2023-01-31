using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using Assets.Source.Scripts.Infrustructure.Services.StaticData;

namespace Assets.Source.Scripts.AbilitiesSystem.Factories
{
    public class EffectsFactory
    {
        private IUpdater _updater;

        public EffectsFactory(IUpdater updater)
        {
            _updater = updater;
        }

        public GamePlayEffect CreateEffect(GamePlayEffectStaticData effectData)
        {

            return new GamePlayEffect(effectData.Duration, effectData.Frequency, effectData.DamagePerPeriod, effectData.InstantDamage, _updater);
        }
    }

    public class AbilityFactory
    {
        private IStaticDataService _staticData;

        public Ability CreateAbility(string name)
        {
            AbilityStaticData abilityData = _staticData.ForAbility(name);

            Ability ability;

            switch (abilityData.TargetDetermineTypeId)
            {
                case AbilityTargetDetermineTypeId.Single:
                    ability = new SingleAbility(abilityData.Effects);
                    break;
                case AbilityTargetDetermineTypeId.Area:
                    ability = new AreaAbility(abilityData.Effects);
                    break;
                case AbilityTargetDetermineTypeId.Chain:
                    ability = new ChainAbility(abilityData.Effects);
                    break;
            }


            return ability;
        }
    }
}
