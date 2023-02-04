using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure.StaticData
{
    [CreateAssetMenu(fileName = "LevelData", menuName ="StaticData/Level")]
    public class SceneStaticData : ScriptableObject
    {
        public string SceneKey;

        [Range(0.5f, 2)]
        public float SecondsBetweenSpawn = 2;

        public List<EnemySpawnPoint> EnemySpawnPoint;
        public List<VaweData> VawesData;
    }
}