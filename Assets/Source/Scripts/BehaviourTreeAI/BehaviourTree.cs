using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Source.Scripts.BehaviourTreeAI
{
    [CreateAssetMenu()]
    public class BehaviourTree : ScriptableObject
    {
        public Node RootNode;
        public State TreeState = State.RUNNING;

        public List<Node> Nodes = new List<Node>();
                
        public State Update()
        {
            if(RootNode.State == State.RUNNING)
                TreeState = RootNode.Update();

            return TreeState;
        }

        public Node CreateNode(System.Type type)
        {
            Node node = ScriptableObject.CreateInstance(type) as Node;
            node.name = type.Name;
            node.Guid = GUID.Generate().ToString();
            Nodes.Add(node);

            AssetDatabase.AddObjectToAsset(node, this);
            AssetDatabase.SaveAssets();
            return node;
        }

        public void DeleteNode(Node node)
        {
            Nodes.Remove(node);
            AssetDatabase.RemoveObjectFromAsset(node);
            AssetDatabase.SaveAssets();
        }

        public void AddChild(Node parrent, Node child)
        {
            if(parrent is DecoratorNode decorator)
                decorator.child = child;

            if (parrent is RootNode rootNode)
                rootNode.child = child;

            if (parrent is CompositeNode composite)
                composite.Children.Add(child);
        }

        public void RemoveChild(Node parrent, Node child)
        {
            if (parrent is DecoratorNode decorator)
                decorator.child = null;

            if (parrent is RootNode rootNode)
                rootNode.child = null;

            if (parrent is CompositeNode composite)
                composite.Children.Remove(child);
        }

        public List<Node> GetChildren(Node parrent)
        {
            List<Node> children = new List<Node>();

            if (parrent is DecoratorNode decorator && decorator.child != null)
                children.Add(decorator.child);

            if (parrent is RootNode rootNode && rootNode.child != null)
                children.Add(rootNode.child);

            if (parrent is CompositeNode composite)
                return composite.Children;
                
            return children;

        }

        public BehaviourTree Clone()
        {
            BehaviourTree tree = Instantiate(this);
            tree.RootNode = tree.RootNode.Clone();

            return tree;
        }
    }
}
