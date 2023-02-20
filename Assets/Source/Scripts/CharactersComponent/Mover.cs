using UnityEngine;
using UnityEngine.AI;

namespace Assets.Source.Scripts.CharactersComponent
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private CharacterAnimator _animator;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Context _context;

        private void Awake()
        {
            _navMeshAgent.isStopped = true;
        }

        public void StopMove()
        {
            _navMeshAgent.isStopped = true;
            _navMeshAgent.velocity = Vector3.zero;
            _animator.PlayIdle();
        }

        public void MoveToTarget()
        {
            _navMeshAgent.SetDestination(_context.Target.position);

            if(_navMeshAgent.isStopped == true)
            {
                _animator.PlayRun();
                _navMeshAgent.isStopped = false;
            }
        }
    }
}