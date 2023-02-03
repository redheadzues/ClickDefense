using Assets.Source.Scripts.AbilitiesSystem;
using Assets.Source.Scripts.AbilitiesSystem.Components;
using System;
using UnityEngine;

namespace Assets.Source.Scripts.Enemies
{
    public class ClickReader : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private AbilityTargetComponent _abilityTarget;

        public event Action<IDamageable> Clicked;
        public event Action<IAbilityTarget> AbilityTargetGeted;

        private void OnMouseDown()
        {
            Clicked?.Invoke(_enemy);
            AbilityTargetGeted?.Invoke(_abilityTarget);
        }
    }
}