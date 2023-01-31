using Assets.Source.Scripts.AbilitiesSystem.StaticData;

namespace Assets.Source.Scripts.AbilitiesSystem
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
}
