namespace Assets.Source.Scripts.BehaviourTreeAI
{
    public class RepeatNode : DecoratorNode
    {
        public override void OnStart()
        {            
        }

        public override void OnStop()
        {            
        }

        public override State OnUpdate()
        {
            child.Update();
            return State.RUNNING;
        }
            
    }
}
