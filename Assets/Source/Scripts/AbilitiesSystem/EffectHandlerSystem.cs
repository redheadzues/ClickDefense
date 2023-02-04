using Assets.Source.Scripts.AbilitiesSystem.Attributes;
using Assets.Source.Scripts.AbilitiesSystem.Components;
using System.Collections.Generic;

namespace Assets.Source.Scripts.AbilitiesSystem
{
    public class EffectHandlerSystem
    {
        private readonly AttributeSetterComponent _setter;

        private List<ILastingEffect> _activeEffects = new List<ILastingEffect>();
        private GamePlayAttributesChanger _currentEffectChanger;

        public EffectHandlerSystem(AttributeSetterComponent setter)
        {
            _setter = setter;
        }

        public void Add<TEffect>(TEffect effect) where TEffect : IEffect
        {
            if(effect is ILastingEffect lastingEffect)
                AddEffectInSystem(lastingEffect);

            if(effect is IInstantEffect instantEffect)
                _setter.TakeDamage(instantEffect.InstantDamage);
        }

        private void OnEffectEnded(ILastingEffect effect)
        {
            RemoveEffectFromSystem(effect);
        }

        private void AddEffectInSystem(ILastingEffect effect)
        {
            _activeEffects.Add(effect);
            SubscribeOnEffect(effect);
            PassSetterNewValues();
        }

        private void RemoveEffectFromSystem(ILastingEffect effect)
        {
            UnsubscribeOnEffect(effect);
            _activeEffects.Remove(effect);
            PassSetterNewValues();
        }

        private void PassSetterNewValues()
        {
            SetCurrentAttributesChanger();
            _setter.ChangeCurrentAttributes(_currentEffectChanger);
        }

        private void SubscribeOnEffect(ILastingEffect effect)
        {
            effect.Ended += OnEffectEnded;
            effect.DamageHappend += OnDamageHappend;
            effect.AttributesChanged += SetCurrentAttributesChanger;
        }

        private void UnsubscribeOnEffect(ILastingEffect effect)
        {
            effect.Ended -= OnEffectEnded;
            effect.DamageHappend -= OnDamageHappend;
            effect.AttributesChanged -= SetCurrentAttributesChanger;
        }

        private void SetCurrentAttributesChanger()
        {
            GamePlayAttributesChanger changer = new GamePlayAttributesChanger(0, 0, 0, 0);

            foreach (ILastingEffect effect in _activeEffects)
                changer *= effect.CurrentAttributeChanger;

            _currentEffectChanger = changer;
        }

        private void OnDamageHappend(int damage)
        {
            _setter.TakeDamage(damage);
        }
    }
}
