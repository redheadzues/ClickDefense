using Assets.Source.Scripts.AbilitiesSystem.StaticData;

namespace Assets.Source.Scripts.AbilitiesSystem.Factories
{
    public class EffectsFactory
    {
        private readonly IUpdater _updater;
        private readonly EffectViewSwitcher _effectViewSwitcher;

        public EffectsFactory(IUpdater updater, EffectViewSwitcher effectViewSwitcher)
        {
            _updater = updater;
            _effectViewSwitcher = effectViewSwitcher;
        }

        public GamePlayEffect Create(GamePlayEffectStaticData effectData)
        {
            GamePlayEffect effect = new GamePlayEffect(effectData, _updater);
            
            if(effectData.VFXPrefab != null)
                _effectViewSwitcher.AddEffectView(effect, effectData.VFXPrefab);

            return effect;
        }
    }
}
