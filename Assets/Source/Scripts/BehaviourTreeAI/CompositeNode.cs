using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.BehaviourTreeAI
{
    public abstract class CompositeNode : Node
    {
        [HideInInspector] public List<Node> Children = new List<Node>();

        public override Node Clone()
        {
            CompositeNode node = Instantiate(this);
            node.Children = Children.ConvertAll(x => x.Clone());
            return node;

        }
    }
}
