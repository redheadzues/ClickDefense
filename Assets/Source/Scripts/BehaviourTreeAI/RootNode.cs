namespace Assets.Source.Scripts.BehaviourTreeAI
{
    public class RootNode : Node
    {
        public Node child;

        public override void OnStart()
        {
            
        }

        public override void OnStop()
        {
            
        }

        public override State OnUpdate()
        {
            return child.Update();
        }

        public override Node Clone()
        {
            RootNode rootNode = Instantiate(this);
            rootNode.child = child.Clone();
            return rootNode;

        }
        
    }
}
