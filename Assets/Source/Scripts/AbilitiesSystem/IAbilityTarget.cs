using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem
{
    public interface IAbilityTarget
    {
        IReadOnlyList<AbilityTag> Tags { get; }
        Vector3 Position { get; }
        void TakeEffect(GamePlayEffect effect); 
    }

    public class EffectsFactory
    {
        private Vector3 _position;
        private IUpdater _updater;

        public EffectsFactory(Vector3 position, IUpdater updater)
        {
            _position = position;
            _updater = updater;
        }

        public GamePlayEffect CreateEffect(GamePlayEffectStaticData effectData)
        {


            return new GamePlayEffect(effectData.Duration, effectData.Frequency, effectData.DamagePerPeriod, effectData.InstantDamage);
        }
    }
}
