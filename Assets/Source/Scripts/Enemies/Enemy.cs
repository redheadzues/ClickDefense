using Assets.Source.Scripts.CharactersComponent;
using Assets.Source.Scripts.Infrustructure.StaticData;
using System;
using UnityEngine;

namespace Assets.Source.Scripts.Enemies
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        [SerializeField] private Death _death;

        private int _reward;
        private float _targetPositionX;
        private EnemyTypeId _typeId;

        public float TargetPointX => _targetPositionX;
        public EnemyTypeId TypeId => _typeId;

        public event Action<int> Died;

        private void OnEnable()
        {
            _death.Happend += OnDeathHappend;
        }

        private void OnDisable()
        {
            _death.Happend -= OnDeathHappend;
        }

        public void Construct(int reward, float targetPosition, EnemyTypeId typeId)
        {
            _reward = reward;
            _targetPositionX = targetPosition;
            _typeId = typeId;
        }
        private void OnDeathHappend()
        {
            Died?.Invoke(_reward);
        }
    }
}