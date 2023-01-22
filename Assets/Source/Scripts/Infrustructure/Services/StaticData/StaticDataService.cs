using Assets.Source.Scripts.Infrustructure.StaticData;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Source.Scripts.Infrustructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<EnemyTypeId, EnemyStaticData> _enemies;
        private Dictionary<string, SceneStaticData> _scenes;

        public void Load()
        {
            _enemies = Resources.LoadAll<EnemyStaticData>("StaticData/Enemies").ToDictionary(x => x.EnemyTypeId, x => x);
            _scenes = Resources.LoadAll<SceneStaticData>("StaticData/SceneData").ToDictionary(x => x.SceneKey, x => x);
        }

        public EnemyStaticData ForEnemy(EnemyTypeId typeId) =>
            _enemies.TryGetValue(typeId, out EnemyStaticData enemyStaticData)
            ?
            enemyStaticData : null;

        public SceneStaticData ForLevel()
        {
            string sceneKey = SceneManager.GetActiveScene().name;

            return _scenes.TryGetValue(sceneKey, out SceneStaticData sceneData) ? sceneData : null;
        }

        //private SceneStaticData ExtractSceneData(IStaticDataService staticData)
        //{

        //    SceneStaticData sceneData = staticData.ForLevel(sceneKey);

        //    return sceneData;
        //}

    }
}
