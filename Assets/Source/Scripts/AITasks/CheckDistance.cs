using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace Assets.Source.Scripts.AITasks
{
    public class CheckDistance : Action
    {
        public SharedTransform Target;

        public override TaskStatus OnUpdate()
        {
            if(Target.Value == null)
                return TaskStatus.Failure;

            return Vector3.Distance(transform.position, Target.Value.position) < 5f ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}
