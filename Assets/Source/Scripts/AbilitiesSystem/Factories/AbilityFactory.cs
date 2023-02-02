﻿using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using Assets.Source.Scripts.Infrustructure.Services.StaticData;

namespace Assets.Source.Scripts.AbilitiesSystem.Factories
{
    public class AbilityFactory : IAbilityFactory
    {
        private readonly IStaticDataService _staticData;

        public AbilityFactory(IStaticDataService staticData)
        {
            _staticData = staticData;
        }

        public Ability CreateAbility(string name)
        {
            AbilityStaticData abilityData = _staticData.ForAbility(name);

            switch (abilityData.TargetDetermineTypeId)
            {
                case AbilityTargetDetermineTypeId.Single:
                    return new SingleAbility(abilityData.Effects);
                case AbilityTargetDetermineTypeId.Area:
                    return new AreaAbility(abilityData.Effects);
                case AbilityTargetDetermineTypeId.Chain:
                    return new ChainAbility(abilityData.Effects);
            }

            return null;
        }
    }
}
