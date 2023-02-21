using BehaviorDesigner.Runtime.Tasks;

public class IsAttacking : Conditional
{
    public SharedContext Context;

    public override TaskStatus OnUpdate() => 
        Context.Value.Attacker.IsAttacking ? TaskStatus.Success : TaskStatus.Failure;


}
