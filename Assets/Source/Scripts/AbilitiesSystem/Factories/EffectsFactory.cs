using Assets.Source.Scripts.AbilitiesSystem.StaticData;

namespace Assets.Source.Scripts.AbilitiesSystem.Factories
{
    public class EffectsFactory
    {
        private readonly IUpdater _updater;
        private readonly EffectViewSwitcher _effectViewSwitcher;
        private readonly EffectHandlerSystem _effectHandler;

        public EffectsFactory(IUpdater updater, EffectViewSwitcher effectViewSwitcher, EffectHandlerSystem effectHandler)
        {
            _updater = updater;
            _effectViewSwitcher = effectViewSwitcher;
            _effectHandler = effectHandler;
        }

        public IEffect Create(GamePlayEffectStaticData effectData)
        {
            IEffect effect = GetEffectByType(effectData);

            _effectHandler.Add(effect);

            if (effectData.VFXPrefab != null)
                _effectViewSwitcher.AddEffectView(effect, effectData.VFXPrefab);

            return effect;
        }

        private IEffect GetEffectByType(GamePlayEffectStaticData effectData)
        {
            switch (effectData.DurationTypeId)
            {
                case GamePlayEffecTypesIds.OneTime:
                    return new InstantEffect(effectData.InstantDamage);
                case GamePlayEffecTypesIds.LongEffect:
                    return new LastingEffect(effectData, _updater);
            }

            return null;
        }
    }
}
