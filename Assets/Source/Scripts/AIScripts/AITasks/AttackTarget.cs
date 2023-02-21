using BehaviorDesigner.Runtime.Tasks;

namespace Assets.Source.Scripts.AIScripts.AITasks
{
    public class AttackTarget : Action
    {
        public SharedContext Context;

        public override TaskStatus OnUpdate()
        {
            if(Context.Value.Target.gameObject.activeSelf == false)
                return TaskStatus.Success;

            if (Context.Value.Attacker.IsAttacking == false)
                Context.Value.Attacker.Attack();

            return TaskStatus.Running;
        }
    }
}
