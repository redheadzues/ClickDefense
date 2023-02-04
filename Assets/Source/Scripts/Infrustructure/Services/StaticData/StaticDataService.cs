using Assets.Source.Scripts.AbilitiesSystem.StaticData;
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
        private Dictionary<string, AbilityStaticData> _abilities;
        private PlayerAbilitiesStaticData _playerAbilities;

        public void Load()
        {
            _enemies = Resources.LoadAll<EnemyStaticData>("StaticData/Enemies").ToDictionary(x => x.EnemyTypeId, x => x);
            _scenes = Resources.LoadAll<SceneStaticData>("StaticData/SceneData").ToDictionary(x => x.SceneKey, x => x);
            _abilities = Resources.LoadAll<AbilityStaticData>("StaticData/Abilities").ToDictionary(x => x.Id, x => x);
            _playerAbilities = Resources.Load<PlayerAbilitiesStaticData>("");
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

        public AbilityStaticData ForAbility(string Id) =>
            _abilities.TryGetValue(Id, out AbilityStaticData abilityData)
            ?
            abilityData : null;

        public PlayerAbilitiesStaticData ForPlayerAbility() =>
            _playerAbilities;
    }
}
