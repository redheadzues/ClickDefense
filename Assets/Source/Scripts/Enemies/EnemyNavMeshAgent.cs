using UnityEngine;
using UnityEngine.AI;

namespace Assets.Source.Scripts.Enemies
{
    public class EnemyNavMeshAgent : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;

        private void OnEnable()
        {
            _agent.SetDestination(new Vector3(-30, transform.position.y, transform.position.z));
        }
    }
}