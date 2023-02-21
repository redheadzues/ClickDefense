using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace Assets.Source.Scripts.AIScripts.AITasks
{
    public class CheckDistance : Action
    {
        public SharedContext Context;

        public override TaskStatus OnUpdate()
        {
            if (Context.Value.Target == null || Context.Value.Target.gameObject.activeSelf == false)
                return TaskStatus.Failure;

            return Vector3.Distance(transform.position, Context.Value.Target.position) < Context.Value.Attributes.Range
                ? TaskStatus.Success 
                : TaskStatus.Failure;
        }
    }
}
