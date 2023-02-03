using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using UnityEditor;
using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem.Editor
{
    [CustomEditor(typeof(AbilityStaticData))]
    public class AbilityStaticDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            AbilityStaticData abilityData = (AbilityStaticData)target;

            //GUILayout.BeginHorizontal();
            //abilityData.Icon = EditorGUILayout.ObjectField(abilityData.Icon, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            //abilityData.Description = EditorGUILayout.TextArea(abilityData.Description, GUILayout.Height(50));
            //GUILayout.EndHorizontal();

            if(abilityData.TargetDetermineTypeId == AbilityTargetDetermineTypeId.Area 
                || abilityData.TargetDetermineTypeId == AbilityTargetDetermineTypeId.Chain)
            {
                abilityData.Area = EditorGUILayout.FloatField("Area", abilityData.Area);
            }

            EditorUtility.SetDirty(target);

        }

    }
}
