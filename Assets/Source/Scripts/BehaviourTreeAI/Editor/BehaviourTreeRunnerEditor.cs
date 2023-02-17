using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Assets.Source.Scripts.BehaviourTreeAI.Editor
{
    [CustomEditor(typeof(BehaviourTreeRunner)), CanEditMultipleObjects]
    public class BehaviourTreeRunnerEditor : UnityEditor.Editor
    {
        private HashSet<FieldInfo> _sharedFields;
        private BehaviourTree _tree;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            BehaviourTreeRunner runner = (BehaviourTreeRunner)target;

            if(Application.isPlaying == false)
            {
                UpdateVariables(runner);
                CollectSharedFields(runner);
                CreateStoragePackeges(runner);
                CreateFieldsInInspector(runner);
            }

            EditorUtility.SetDirty(target);
        }


        private void UpdateVariables(BehaviourTreeRunner runner)
        {
            _tree = runner.tree;
            _sharedFields = new HashSet<FieldInfo>();
        }

        private void CollectSharedFields(BehaviourTreeRunner runner) =>
            _tree.Nodes.ForEach(node => _sharedFields.UnionWith(runner.GetSharedFields(node)));


        private void CreateFieldsInInspector(BehaviourTreeRunner runner)
        {
            foreach(var data in runner.PackedData)
            {
                GUILayout.BeginHorizontal();

                GUILayout.Label(data.Name, GUILayout.MinWidth(100), GUILayout.ExpandWidth(true));
                data.Value = EditorGUILayout.ObjectField((UnityEngine.Object)data.Value, data.Type, true);

                GUILayout.EndHorizontal();
            }
        }
        

        private void CreateStoragePackeges(BehaviourTreeRunner runner)
        {
            foreach (FieldInfo info in _sharedFields)
            {
                if (CheckContainsData(info, runner) == false)
                {
                    PackedSharedData newData = new PackedSharedData(info.FieldType, info.Name);
                    runner.PackedData.Add(newData);
                }
            }
        }

        private bool CheckContainsData(FieldInfo info, BehaviourTreeRunner runner)
        {
            foreach(PackedSharedData data in runner.PackedData)
            {
                if(data.Type == info.FieldType && data.Name == info.Name)
                    return true;
            }

            return false;
        }        
    }
}
