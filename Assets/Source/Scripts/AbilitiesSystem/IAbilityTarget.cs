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
        [SerializeField] private List<AbilityTag> _tags;
            
        private List<GamePlayEffect> _activeEffects = new List<GamePlayEffect>();

        public IReadOnlyList<AbilityTag> Tags => _tags;
        public Vector3 Position => transform.position;

        public void TakeEffect(GamePlayEffect effect)
        {
            _activeEffects.Add(effect);
            effect.Ended += OnEffectEnded;
        }

        private void OnEffectEnded(GamePlayEffect effect)
        {
            effect.Ended -= OnEffectEnded;
            _activeEffects.Remove(effect);
        }
    }

    public class AttributeSet : MonoBehaviour
    {

    }

}
