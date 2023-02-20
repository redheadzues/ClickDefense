using UnityEngine;
using UnityEngine.AI;

namespace Assets.Source.Scripts.CharactersComponent
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private CharacterAnimator _animator;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Context _context;

        private bool _isMoving;

        public void StopMove()
        {
            _isMoving = false;
            _animator.PlayIdle();
        }

        public void MoveToTarget()
        {
            _navMeshAgent.SetDestination(_context.Target.position);

            if(_isMoving == false)
                _animator.PlayRun();

            _isMoving = true;
        }

    }
}