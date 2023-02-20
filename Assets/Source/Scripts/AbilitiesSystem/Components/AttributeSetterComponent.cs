﻿using Assets.Source.Scripts.AbilitiesSystem.Attributes;
using Assets.Source.Scripts.CharactersComponent;
using Assets.Source.Scripts.Enemies;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Source.Scripts.AbilitiesSystem.Components
{
    public class AttributeSetterComponent : MonoBehaviour, IDamageable
    {
        [SerializeField] private Health _health;
        [SerializeField] private NavMeshAgent _navMeshAgent;

        private GamePlayAttributes _attributes;
        private GamePlayAttributes _currentAttributes;

        public float Speed => _currentAttributes.Speed;
        public float Damage => _currentAttributes.Damage;
        public float Range => _currentAttributes.Range;
        public float AttackSpeed => _currentAttributes.AttackSpeed;

        public void SetAttributes(GamePlayAttributes attributes)
        {
            _attributes = attributes;
            _currentAttributes = _attributes;
            _navMeshAgent.speed = _currentAttributes.Speed;
        }

        public void ChangeCurrentAttributes(GamePlayAttributesChanger changer)
        {
            _currentAttributes = _attributes.ChangeAttributes(changer);
            _navMeshAgent.speed = _currentAttributes.Speed;
        }

        public void RestoreToDefalut()
        {
            _currentAttributes = _attributes;
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }
    }
}
