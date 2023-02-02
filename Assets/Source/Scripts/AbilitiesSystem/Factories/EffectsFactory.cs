﻿using Assets.Source.Scripts.AbilitiesSystem.StaticData;

namespace Assets.Source.Scripts.AbilitiesSystem.Factories
{
    public class EffectsFactory
    {
        private IUpdater _updater;

        public EffectsFactory(IUpdater updater)
        {
            _updater = updater;
        }

        public GamePlayEffect Create(GamePlayEffectStaticData effectData)
        {

            return new GamePlayEffect(effectData.Duration, effectData.Frequency, effectData.DamagePerPeriod, effectData.InstantDamage, _updater, effectData.AttributesChanger);
        }
    }
}
