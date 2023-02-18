using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class DefineDestination : Action
{
    public SharedVector3 Destination;

    public override TaskStatus OnUpdate()
    {
        Destination.Value = transform.position + Vector3.left * 30;

        return TaskStatus.Success;
    }
}
