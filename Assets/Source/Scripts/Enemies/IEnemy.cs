using Assets.Source.Scripts.CharactersComponent;
using Assets.Source.Scripts.Infrustructure.StaticData;
using System;
using UnityEngine;

namespace Assets.Source.Scripts.Enemies
{
    public interface IEnemy : IDamageable, IHealth
    {
        int Reward { get; set; }
        Vector3 Position { get; }
        public EnemyTypeId TypeId { get; set; }
        event Action<IEnemy> Died;
    }
}