using Assets.Source.Scripts.AbilitiesSystem.Factories;
using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem.Components
{
    public class AbilityTargetComponent : MonoBehaviour, IAbilityTarget, IUpdater
    {
        [SerializeField] private List<AbilityTag> _tags;
        [SerializeField] private AttributeSetterComponent _setter;

        private EffectsFactory _effectsFactory;

        public IReadOnlyList<AbilityTag> Tags => _tags;
        public Vector3 Position => transform.position;
        public event Action<float> Updated;

        private void Awake()
        {
            EffectViewSwitcher effectViewSwitcher = new EffectViewSwitcher(transform);
            EffectHandlerSystem effectHandler= new EffectHandlerSystem(_setter);
            _effectsFactory = new EffectsFactory(this, effectViewSwitcher, effectHandler);
        }

        private void Update() => 
            Updated?.Invoke(Time.deltaTime);

        public void TakeEffect(GamePlayEffectStaticData effectData) => 
            _effectsFactory.Create(effectData);


    }
}
