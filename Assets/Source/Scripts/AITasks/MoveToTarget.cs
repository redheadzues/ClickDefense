using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Source.Scripts.AITasks
{
    public class MoveToTarget : Action
    {
        public SharedTransform Target;
        private float threshold = 1.5f;

        public SharedGameObject targetGameObject;
        private NavMeshAgent navMeshAgent;
        private GameObject prevGameObject;

        public override void OnStart()
        {
            var currentGameObject = GetDefaultGameObject(targetGameObject.Value);
            if (currentGameObject != prevGameObject)
            {
                navMeshAgent = currentGameObject.GetComponent<NavMeshAgent>();
                prevGameObject = currentGameObject;
            }
        }

        public override TaskStatus OnUpdate()
        {
            return CheckDistance() ? TaskStatus.Success : TaskStatus.Running;
        }

        private bool CheckDistance()
        {
            if (Vector3.Distance(transform.position, Target.Value.position) > threshold)
            {
                CorrectDestinationPoint();
                return false;
            }
            else
                return true;
        }

        private void CorrectDestinationPoint()
        {
            navMeshAgent.SetDestination(Target.Value.position);
        }

    }
}
