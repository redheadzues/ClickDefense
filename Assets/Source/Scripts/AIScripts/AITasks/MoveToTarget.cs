using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Source.Scripts.AIScripts.AITasks
{
    public class MoveToTarget : Action
    {
        public SharedContext Context;
        private float threshold = 3f;



        public override TaskStatus OnUpdate()
        {
            return CheckDistance() ? TaskStatus.Success : TaskStatus.Running;
        }

        private bool CheckDistance()
        {
            if (Vector3.Distance(transform.position, Context.Value.Target.position) > threshold)
            {
                CorrectDestinationPoint();
                return false;
            }
            else
                return true;
        }

        private void CorrectDestinationPoint()
        {
            Context.Value.Mover.MoveToTarget();
        }

    }
}
