using Assets.Source.Scripts.AbilitiesSystem;
using Assets.Source.Scripts.AbilitiesSystem.Components;
using Assets.Source.Scripts.CharactersComponent;
using System;
using UnityEngine;

namespace Assets.Source.Scripts.Enemies
{
    public class ClickReader : MonoBehaviour
    {
        [SerializeField] private AttributeSetterComponent _attributeSetter;
        [SerializeField] private AbilityTargetComponent _abilityTarget;

        public event Action<IDamageable> Clicked;
        public event Action<IAbilityTarget> AbilityTargetGeted;

        private void OnMouseDown()
        {
            Clicked?.Invoke(_attributeSetter);
            AbilityTargetGeted?.Invoke(_abilityTarget);
        }
    }
}