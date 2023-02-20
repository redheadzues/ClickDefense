using UnityEngine;

namespace Assets.Source.Scripts.CharactersComponent
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private readonly int Run = Animator.StringToHash("Run");
        private readonly int Attack = Animator.StringToHash("Attack");
        private readonly int Idle = Animator.StringToHash("Idle");
        private readonly int Die = Animator.StringToHash("Die");

        public void PlayRun() =>
            _animator.SetTrigger(Run);

        public void PlayAttack() =>
            _animator.SetTrigger(Attack);

        public void PlayIdle() =>
            _animator.SetTrigger(Idle);

        public void PlayDie() =>
            _animator.SetTrigger(Die);

    }
}
