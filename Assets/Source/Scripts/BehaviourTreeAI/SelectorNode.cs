namespace Assets.Source.Scripts.BehaviourTreeAI
{
    public class SelectorNode : CompositeNode
    {
        public override State OnEvaluate(float time)
        {
            foreach(Node child in Children)
            {
                switch (child.Evaluate(time))
                {
                    case State.RUNNING:
                        return State.RUNNING;
                    case State.FAILURE:
                        break;
                    case State.SUCCESS:
                        return State.SUCCESS;
                }
            }

            return State.FAILURE;
        }
    }
}