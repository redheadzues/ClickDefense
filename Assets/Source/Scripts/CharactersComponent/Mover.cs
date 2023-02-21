using UnityEngine;
using UnityEngine.AI;

namespace Assets.Source.Scripts.CharactersComponent
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private CharacterAnimator _animator;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Context _context;

        public void StopMove()
        {
            _navMeshAgent.velocity = Vector3.zero;
        }

        public void MoveToTarget()
        {
            _animator.PlayRun();

            _navMeshAgent.SetDestination(_context.Target.position);
        }
    }
}