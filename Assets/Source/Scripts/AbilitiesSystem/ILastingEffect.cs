using Assets.Source.Scripts.AbilitiesSystem.Attributes;
using System;

namespace Assets.Source.Scripts.AbilitiesSystem
{
    public interface ILastingEffect : IEffect
    {
        GamePlayAttributesChanger CurrentAttributeChanger { get; }
        event Action<LastingEffect> Ended;
        event Action AttributesChanged;
        event Action<int> DamageHappend;
    }

    public interface IInstantEffect : IEffect
    {
        int InstantDamage { get; }
    }

    public interface IEffect
    {   

    }
}