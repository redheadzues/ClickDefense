using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem
{
    public interface IAbilityTarget
    {
        IReadOnlyList<AbilityTag> Tags { get; }
        Vector3 Position { get; }
        void TakeEffect(GamePlayEffect effect); 
    }

    public class AbilityTargetComponent : MonoBehaviour, IAbilityTarget
    {
        public IReadOnlyList<AbilityTag> Tags => throw new System.NotImplementedException();

        public Vector3 Position => transform.position;

        private List<GamePlayEffect> _activeEffects = new List<GamePlayEffect>();

        public void TakeEffect(GamePlayEffect effect)
        {
            _activeEffects.Add(effect);
        }
    }

}
