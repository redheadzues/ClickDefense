using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem
{
    public interface IAbilityTarget
    {
        IReadOnlyList<AbilityTag> Tags { get; }
        Vector3 Position { get; }
        void TakeEffect(GamePlayEffectStaticData effect); 
    }
}
