using Assets.Source.Scripts.AbilitiesSystem.Attributes;
using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem
{
    public class AttributeSetter : MonoBehaviour
    {
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
        }

        public void ChangeCurrentAttributes(GamePlayAttributesChanger changer)
        {
            _currentAttributes = _attributes.ChangeAttributes(changer);
        }

        public void RestoreToDefalut()
        {
            _currentAttributes = _attributes;
        }

        public void TakeDamage(int damage)
        {
            
        }
    }
}
