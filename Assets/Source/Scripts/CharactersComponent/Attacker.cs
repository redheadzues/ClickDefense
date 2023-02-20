using UnityEngine;

namespace Assets.Source.Scripts.CharactersComponent
{
    public class Attacker : MonoBehaviour
    {
        [SerializeField] private CharacterAnimator _animator;
        [SerializeField] private Context _context;

        private bool _isAttacking;

        public void Attack()
        {
            if(_isAttacking == false )
                _animator.PlayAttack();

            _isAttacking = true;
        }

        public void AttackEnded() =>
            _isAttacking = false;   

        public void DealDamage() =>
            _context.TargetHealth.TakeDamage((int)_context.Attributes.Damage);        
    }
}
