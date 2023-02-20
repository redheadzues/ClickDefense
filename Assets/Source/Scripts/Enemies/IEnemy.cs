using Assets.Source.Scripts.Infrustructure.StaticData;
using System;

namespace Assets.Source.Scripts.Enemies
{
    public interface IEnemy
    {
        public EnemyTypeId TypeId { get;  }
        float TargetPointX { get; }
        event Action<int> Died;
    }
}