using Assets.Source.Scripts.AbilitiesSystem.Attributes;
using Assets.Source.Scripts.Enemies;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Source.Scripts.AbilitiesSystem.Components
{
    public class AttributeSetterComponent : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private NavMeshAgent _navMeshAgent;

        private GamePlayAttributes _attributes;
        private GamePlayAttributes _currentAttributes;

        public float Speed => _currentAttributes.Speed;
        public float Damage => _currentAttributes.Damage;
        public float Range => _currentAttributes.Range;
        public float AttackSpeed => _currentAttributes.AttackSpeed;

        public void SetAttributes(float speed = 0, float damage = 0, float range = 0, float attackSpeed = 0)
        {
            _attributes = new GamePlayAttributes(speed, damage, range, attackSpeed);
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
            _enemy.TakeDamage(damage);
        }
    }
}
