﻿using Assets.Source.Scripts.AbilitiesSystem.Components;
using Assets.Source.Scripts.CharactersComponent;
using Assets.Source.Scripts.Enemies;
using Assets.Source.Scripts.Infrustructure.Services.ClickListener;
using Assets.Source.Scripts.Infrustructure.Services.Reward;
using Assets.Source.Scripts.Infrustructure.Services.StaticData;
using Assets.Source.Scripts.Infrustructure.StaticData;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure.Services.Factories
{
    public class CharacterFactory : ICharacterFactory
    {
        private readonly IClickInformer _clickInformer;
        private readonly IRewarder _rewarder;
        private readonly IStaticDataService _staticData;

        public CharacterFactory(IClickInformer clickInformer, IRewarder rewarder, IStaticDataService staticData)
        {
            _clickInformer = clickInformer;
            _rewarder = rewarder;
            _staticData = staticData;
        }

        public GameObject CreateAllie(AllieTypeId typeId)
        {
            AllieStaticData allieData = _staticData.ForAllie(typeId);

            GameObject allie = Object.Instantiate(allieData.Prefab);
            allie.GetComponent<AttributeSetterComponent>().SetAttributes(allieData.Attributes);
            allie.GetComponent<Health>().SetNewValue(allieData.HP);

            return allie;
        }

        public GameObject CreateEnemy( EnemyTypeId enemyTypeId)
        {
            EnemyStaticData enemyData = _staticData.ForEnemy(enemyTypeId);
            SceneStaticData sceneStaticData = _staticData.ForLevel();
            GameObject enemy = Object.Instantiate(enemyData.Prefab);

            RegisterEnemy(enemy);
            SetupEnemy(enemyData, enemy, sceneStaticData.EnemyTargetPositionX);

            return enemy;
        }

        private void SetupEnemy(EnemyStaticData enemyData, GameObject enemy, float destinationtPositionX)
        {
            enemy.GetComponent<Health>().SetNewValue(enemyData.HP);
            enemy.GetComponent<AttributeSetterComponent>().SetAttributes(enemyData.Attributes);
            
            Enemy enemySource = enemy.GetComponent<Enemy>();

            enemySource.Construct(enemyData.Reward, destinationtPositionX, enemyData.EnemyTypeId);
        }

        private void RegisterEnemy(GameObject enemy)
        {
            _clickInformer.Register(enemy.GetComponent<ClickReader>());
            _rewarder.Register(enemy.GetComponent<IEnemy>());
        }
    }
}
