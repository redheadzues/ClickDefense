using BehaviorDesigner.Runtime.Tasks;

namespace Assets.Source.Scripts.AIScripts.AITasks
{
    public class AttackTarget : Action
    {
        public SharedContext Context;

        public override TaskStatus OnUpdate()
        {
            if (Context.Value.Attacker.IsAttacking == false)
            {
                Context.Value.Attacker.Attack();
                return TaskStatus.Success;
            }

            return TaskStatus.Running;
        }
    }
}
