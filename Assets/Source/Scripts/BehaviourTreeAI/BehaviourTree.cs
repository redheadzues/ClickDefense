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
            node.Id = GUID.Generate().ToString();
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
    }
}
