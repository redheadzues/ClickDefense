using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Assets.Source.Scripts.BehaviourTreeAI
{
    public class BehaviourTreeRunner : MonoBehaviour
    {
        public BehaviourTree tree;

        [HideInInspector] public List<PackedSharedData> PackedData;

        private void Start()
        {
            tree = tree.Clone();
            EnjectData();
        }

        private void Update()
        {
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
                else
                    Debug.LogWarning($"Empty value in {data.Type} {data.Name}");
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
                    shared.SetValue(node, data.Value);
            }
        }
    }
}
