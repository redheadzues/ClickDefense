using System;

namespace Assets.Source.Scripts.AbilitiesSystem
{
    public interface ILastingEffect : IEffect
    {
        event Action<GamePlayEffect> Ended;
        event Action<int> DamageHappend;
    }

    public interface IInstantEffect
    { 
    }

    public interface IEffect
    {   
        int InstantDamage { get; }
    }
}