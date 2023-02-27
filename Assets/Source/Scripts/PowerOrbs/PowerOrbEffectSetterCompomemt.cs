using Assets.Source.Scripts.AbilitiesSystem;
using Assets.Source.Scripts.AbilitiesSystem.Components;
using Assets.Source.Scripts.AbilitiesSystem.Factories;
using Assets.Source.Scripts.Allies;
using Assets.Source.Scripts.MergingGrid;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.PowerOrbs
{
    public class PowerOrbEffectSetterCompomemt : MonoBehaviour, IUpdater
    {
        [SerializeField] private AttributeSetterComponent _attributeSetter;
        [SerializeField] private AllieMerger _allieMerger;

        private EffectsFactory _effectsFactory;
        private List<IEffect> _activeEffects = new List<IEffect>();

        public event Action<float> Updated;

        private void Awake()
        {
            EffectViewSwitcher effectViewSwitcher = new EffectViewSwitcher(transform);
            EffectHandlerSystem effectHandler = new EffectHandlerSystem(_attributeSetter);
            _effectsFactory = new EffectsFactory(this, effectViewSwitcher, effectHandler);
        }

        private void OnEnable() => 
            _allieMerger.OrbsUpdated += OnOrbsUpdated;

        private void OnDisable() => 
            _allieMerger.OrbsUpdated -= OnOrbsUpdated;

        private void Update() =>
            Updated?.Invoke(Time.deltaTime);

        private void OnOrbsUpdated()
        {
            _activeEffects.ForEach(effect => effect.Abort());
            _activeEffects.Clear();

            foreach(IMergeableChild child in _allieMerger.Children)
            {
                if (child is PowerOrb powerorb)
                {
                    IEffect effect = _effectsFactory.Create(powerorb.GiveEffect());
                    _activeEffects.Add(effect);
                }
            }
        }
    }
}
