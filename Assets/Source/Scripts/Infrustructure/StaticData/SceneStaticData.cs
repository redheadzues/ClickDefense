using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure.StaticData
{
    [CreateAssetMenu(fileName = "LevelData", menuName ="StaticData/Level")]
    public class SceneStaticData : ScriptableObject
    {
        public string SceneKey;
        public List<EnemySpawnPoint> EnemySpawnPoint;
        [Range(0.5f, 2)]
        public float SecondsBetweenSpawn = 2;
        public EnemyTypeId EnemyTypeId;

    }
}