namespace Assets.Source.Scripts.BehaviourTreeAI
{
    public class RootNode : Node
    {
        public Node child;

        public override State OnEvaluate()
        {
            return child.Evaluate();
        }

        public override Node Clone()
        {
            RootNode rootNode = Instantiate(this);
            rootNode.child = child.Clone();
            return rootNode;
        }        
    }
}
