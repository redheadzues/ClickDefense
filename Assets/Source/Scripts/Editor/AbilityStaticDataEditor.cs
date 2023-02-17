using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem.Editor
{
    [CustomEditor(typeof(AbilityStaticData))]
    public class AbilityStaticDataEditor : UnityEditor.Editor
    {
        private void OnEnable()
        {
            AbilityStaticData abilityData = (AbilityStaticData)target;

            if (string.IsNullOrEmpty(abilityData.Id))
                Generate(abilityData);
        }

        private void Generate(AbilityStaticData abilityData)
        {
            abilityData.Id = Guid.NewGuid().ToString() + DateTime.Now.ToString("HH-mm-ss-dd-mm-yyyy-m");
            EditorUtility.SetDirty(abilityData);
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            AbilityStaticData abilityData = (AbilityStaticData)target;

            //GUILayout.BeginHorizontal();
            //GUILayout.Label("Icon");
            //GUILayout.Label("Description");
            //GUILayout.EndHorizontal();

            //GUILayout.BeginHorizontal();
            //abilityData.Icon = EditorGUILayout.ObjectField(abilityData.Icon, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            //abilityData.Description = EditorGUILayout.TextArea(abilityData.Description, GUILayout.Height(50));
            //GUILayout.EndHorizontal();

            //GUILayout.BeginHorizontal();
            //GUILayout.Label("Name: ", GUILayout.Width(50));
            //abilityData.Name = EditorGUILayout.TextArea(abilityData.Name);
            //GUILayout.EndHorizontal();

            //if (abilityData.TargetDetermineTypeId == AbilityTargetDetermineTypeId.Area
            //    || abilityData.TargetDetermineTypeId == AbilityTargetDetermineTypeId.Chain)
            //{
            //    abilityData.Area = EditorGUILayout.FloatField("Area", abilityData.Area);
            //}

            //GUILayout.Label($"Unique Id - {abilityData.Id}");

            EditorUtility.SetDirty(target);

        }

    }
}
