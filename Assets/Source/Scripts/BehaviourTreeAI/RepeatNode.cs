namespace Assets.Source.Scripts.BehaviourTreeAI
{
    public class RepeatNode : DecoratorNode
    {
        public override State OnEvaluate()
        {
            child.Evaluate();
            return State.RUNNING;
        }           
    }
}
