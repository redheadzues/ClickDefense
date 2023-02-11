using System.Collections.Generic;

namespace Assets.Source.Scripts.BehaviourTreeAI
{
    public abstract class CompositeNode : Node
    {
        public List<Node> Children = new List<Node>();
    }
}
