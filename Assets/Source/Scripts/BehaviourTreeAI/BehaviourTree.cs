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

            Undo.RecordObject(this, "Behaviour Tree (Create Node)");

            AssetDatabase.AddObjectToAsset(node, this);
            Undo.RegisterCreatedObjectUndo(node, "Behaviour Tree (Create Node)");
            AssetDatabase.SaveAssets();
            return node;
        }

        public void DeleteNode(Node node)
        {
            Undo.RecordObject(this, "Behaviour Tree (Delete Node)");
            Nodes.Remove(node);
            //AssetDatabase.RemoveObjectFromAsset(node);
            Undo.DestroyObjectImmediate(node);
            AssetDatabase.SaveAssets();
        }

        public void AddChild(Node parrent, Node child)
        {
            if(parrent is DecoratorNode decorator)
            {
                Undo.RecordObject(decorator, "Behaviour Tree (Add Child)");
                decorator.child = child;
                EditorUtility.SetDirty(decorator);

            }

            if (parrent is RootNode rootNode)
            {
                Undo.RecordObject(rootNode, "Behaviour Tree (Add Child)");
                rootNode.child = child;
                EditorUtility.SetDirty(rootNode);
            }

            if (parrent is CompositeNode composite)
            {
                Undo.RecordObject(composite, "Behaviour Tree (Add Child)");
                composite.Children.Add(child);
                EditorUtility.SetDirty(composite);
            }
        }

        public void RemoveChild(Node parrent, Node child)
        {
            if (parrent is DecoratorNode decorator)
            {
                Undo.RecordObject(decorator, "Behaviour Tree (Remove Child)");
                decorator.child = null;
                EditorUtility.SetDirty(decorator);
            }

            if (parrent is RootNode rootNode)
            {
                Undo.RecordObject(rootNode, "Behaviour Tree (Remove Child)");
                rootNode.child = null;
                EditorUtility.SetDirty(rootNode);
            }

            if (parrent is CompositeNode composite)
            {
                Undo.RecordObject(composite, "Behaviour Tree (Remove Child)");
                composite.Children.Remove(child);
                EditorUtility.SetDirty(composite);
            }
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
