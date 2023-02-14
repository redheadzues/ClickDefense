namespace Assets.Source.Scripts.BehaviourTreeAI
{
    public class SelectorNode : CompositeNode
    {
        public override void OnStart(){}

        public override void OnStop(){}

        public override State OnUpdate()
        {
            foreach(Node child in Children)
            {
                switch (child.Update())
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