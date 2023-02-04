using Assets.Source.Scripts.AbilitiesSystem.Attributes;
using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using System;

namespace Assets.Source.Scripts.AbilitiesSystem
{
    public class LastingEffect : ILastingEffect
    {
        private readonly float _duration;
        private readonly float _effectFrequency;
        private readonly int _damagePerPeriod;
        private readonly IUpdater _updater;

        private float _elapsedDuration;
        private float _elapsedFrequency;

        public GamePlayAttributesChanger CurrentAttributeChanger { get; private set; }
        public event Action<LastingEffect> Ended;
        public event Action<int> DamageHappend;
        public event Action AttributesChanged;

        public LastingEffect(GamePlayEffectStaticData effectData, IUpdater updater)
        {
            _duration = effectData.Duration;
            _effectFrequency = effectData.Frequency;
            _damagePerPeriod = effectData.DamagePerPeriod;
            CurrentAttributeChanger = effectData.AttributesChanger;
            _updater = updater;
            _updater.Updated += OnUpdate;
        }


        private void OnUpdate(float deltaTime)
        {
            _elapsedFrequency += deltaTime;
            _elapsedDuration += deltaTime;

            if(_elapsedFrequency >= _effectFrequency)
            {
                _elapsedFrequency -= _effectFrequency;
                DamageHappend?.Invoke(_damagePerPeriod);
            }

            if (_elapsedDuration >= _duration)
            {
                _updater.Updated -= OnUpdate;
                Ended?.Invoke(this);
            }
        }
    }
}
