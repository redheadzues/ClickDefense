using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Assets.Source.Scripts.BehaviourTreeAI
{
    [ExecuteInEditMode]
    public class BehaviourTreeRunner : MonoBehaviour
    {
        public BehaviourTree tree;

        public List<PackedSharedData> PackedData = new List<PackedSharedData>();

        private void Awake()
        {
            tree = tree.Clone();
        }

        private void Start()
        {

        }

        private void Update()
        {
            EnjectData();
            if (Application.isPlaying)
                tree.Evaluate(Time.deltaTime);
        }

        public List<FieldInfo> GetSharedFields(Node node) =>
            node.GetNodeType().GetFields().Where(field => Attribute.IsDefined(field, typeof(Shared))).ToList();

        private void EnjectData()
        {
            foreach(PackedSharedData data in PackedData)
            {
                if(data.Value != null)
                    EnjectInNode(data);               
            }
        }

        private void EnjectInNode(PackedSharedData data) =>
            tree.Nodes.ForEach(node => EnjectInFields(data, node));

        private void EnjectInFields(PackedSharedData data, Node node)
        {
            List<FieldInfo> sharedFields = GetSharedFields(node);

            foreach (FieldInfo shared in sharedFields)
            {
                if (data.Type == shared.FieldType && data.Name == shared.Name)
                {                    
                    shared.SetValue(node, data.Value);
                }
            }
        }
    }
}
