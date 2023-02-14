namespace Assets.Source.Scripts.BehaviourTreeAI
{
    public class RootNode : Node
    {
        public Node child;

        public override State OnEvaluate(float time)
        {
            return child.Evaluate(time);
        }

        public override Node Clone()
        {
            RootNode rootNode = Instantiate(this);
            rootNode.child = child.Clone();
            return rootNode;
        }        
    }
}
