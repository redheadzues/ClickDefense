using Assets.Source.Scripts.Infrustructure.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<EnemyTypeId, EnemyStaticData> _enemies;
        private Dictionary<string, SceneStaticData> _scenes;

        public void Load()
        {
            _enemies = Resources.LoadAll<EnemyStaticData>("StaticData/Enemies").ToDictionary(x => x.EnemyTypeId, x => x);
            _scenes = Resources.LoadAll<SceneStaticData>("StaticData/Levels").ToDictionary(x => x.SceneKey, x => x);
        }

        public EnemyStaticData ForEnemy(EnemyTypeId typeId) =>
            _enemies.TryGetValue(typeId, out EnemyStaticData enemyStaticData)
            ?
            enemyStaticData : null;

        public SceneStaticData ForLevel(string sceneKey) =>
            _scenes.TryGetValue(sceneKey, out SceneStaticData sceneData)
            ?
            sceneData : null;
    }
}
