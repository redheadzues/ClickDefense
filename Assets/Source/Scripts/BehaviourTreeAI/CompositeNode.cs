using System.Collections.Generic;

namespace Assets.Source.Scripts.BehaviourTreeAI
{
    public abstract class CompositeNode : Node
    {
        List<Node> _children = new List<Node>();
    }
}
