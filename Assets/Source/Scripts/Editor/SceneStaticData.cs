using Assets.Source.Scripts.GameOver;
using Assets.Source.Scripts.Infrustructure.StaticData;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Source.Scripts.Editor
{
    [CustomEditor(typeof(SceneStaticData))]
    public class SceneDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            SceneStaticData sceneData = (SceneStaticData)target;

            if (GUILayout.Button("Collect"))
            {
                sceneData.EnemySpawnPoint = 
                    FindObjectsOfType<SpawnPoint>()
                    .Select(x => new EnemySpawnPoint(x.transform.position))
                    .ToList();

                sceneData.EnemyTargetPositionX = FindObjectOfType<TargetPoint>().transform.position.x;

                sceneData.SceneKey = SceneManager.GetActiveScene().name;
            }

            EditorUtility.SetDirty(target);
        }
    }
}