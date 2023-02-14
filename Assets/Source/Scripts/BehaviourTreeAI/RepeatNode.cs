namespace Assets.Source.Scripts.BehaviourTreeAI
{
    public class RepeatNode : DecoratorNode
    {
        public override State OnEvaluate(float time)
        {
            child.Evaluate(time);
            return State.RUNNING;
        }           
    }
}
