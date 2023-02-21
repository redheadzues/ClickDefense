using UnityEngine;

namespace Assets.Source.Scripts.CharactersComponent
{
    public class Attacker : MonoBehaviour
    {
        [SerializeField] private CharacterAnimator _animator;
        [SerializeField] private Context _context;

        private bool _isAttacking;

        public bool IsAttacking => _isAttacking;

        public void Attack()
        {
            if (_isAttacking == false )
            {
                _animator.SetSpeed(_context.Attributes.AttackSpeed);
                _animator.PlayAttack();
                transform.LookAt(_context.Target);
                _isAttacking = true;
            }
        }

        public void AttackEnded()
        {
            _isAttacking = false;
            _animator.SetSpeed(1);
        }


        public void DealDamage() =>
            _context.TargetHealth.TakeDamage((int)_context.Attributes.Damage);        
    }
}
