using System;
using UnityEngine;

namespace Assets.Source.Scripts.Enemies
{
    public interface IEnemy : IDamageable, IHealth
    {
        int Reward { get; set; }
        Vector3 Position { get; }
        event Action<IEnemy> Died;
    }
}