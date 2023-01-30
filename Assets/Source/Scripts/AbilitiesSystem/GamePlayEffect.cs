using Assets.Source.Scripts.AbilitiesSystem.Attributes;
using System;

namespace Assets.Source.Scripts.AbilitiesSystem
{
    public class GamePlayEffect : ILastingEffect
    {
        public GamePlayAttributesChanger CurrentAttributeChanger;

        private readonly float _duration;
        private readonly float _effectFrequency;
        private readonly int _damagePerPeriod;
        private readonly int _instantDamage;

        private float _elapsedDuration;
        private float _elapsedFrequency;
        public int InstantDamage => _instantDamage;
        public event Action<GamePlayEffect> Ended;
        public event Action<int> DamageHappend;

        public GamePlayEffect(float duration, float effectFrequency, int damagePerPeriod, int instantDamage)
        {
            _duration = duration;
            _effectFrequency = effectFrequency;
            _damagePerPeriod = damagePerPeriod;
            _instantDamage = instantDamage;
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
                Ended?.Invoke(this);
            }
        }
    }
}
