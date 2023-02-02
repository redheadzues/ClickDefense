using Assets.Source.Scripts.AbilitiesSystem.Attributes;
using Assets.Source.Scripts.AbilitiesSystem.Factories;
using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem
{
    public class AbilityTargetComponent : MonoBehaviour, IAbilityTarget, IUpdater
    {
        [SerializeField] private List<AbilityTag> _tags;
        [SerializeField] private AttributeSetter _setter;

        public GamePlayAttributesChanger CurrentChanger => GetCurrentAttributesChanger();
        private EffectsFactory _effectsFactory;
        private List<GamePlayEffect> _activeEffects = new List<GamePlayEffect>();

        public IReadOnlyList<AbilityTag> Tags => _tags;
        public Vector3 Position => transform.position;
        public Transform Transform => transform;
        public event Action<float> Updated;

        private void Awake()
        {
            _effectsFactory = new EffectsFactory(this);
        }

        private void Update()
        {
            Updated?.Invoke(Time.deltaTime);
        }

        public void TakeEffect(GamePlayEffectStaticData effectData)
        {
            GamePlayEffect effect = _effectsFactory.CreateEffect(effectData);
            AddEffectInSystem(effect);
        }

        private void OnEffectEnded(GamePlayEffect effect)
        {
            RemoveEffectFromSystem(effect);
        }

        private void AddEffectInSystem(GamePlayEffect effect)
        {
            _activeEffects.Add(effect);
            OnDamageHappend(effect.InstantDamage);
            effect.Ended += OnEffectEnded;
            effect.DamageHappend += OnDamageHappend;
            _setter.ChangeCurrentAttributes(CurrentChanger);
        }

        private void RemoveEffectFromSystem(GamePlayEffect effect)
        {
            effect.Ended -= OnEffectEnded;
            effect.DamageHappend -= OnDamageHappend;
            _activeEffects.Remove(effect);
            _setter.ChangeCurrentAttributes(CurrentChanger);
        }

        private GamePlayAttributesChanger GetCurrentAttributesChanger()
        {
            GamePlayAttributesChanger changer = new GamePlayAttributesChanger();

            foreach (GamePlayEffect effect in _activeEffects)
                changer *= effect.CurrentAttributeChanger;

            return changer;
        }

        private void OnDamageHappend(int damage)
        {
            _setter.TakeDamage(damage);
        }
    }
}
