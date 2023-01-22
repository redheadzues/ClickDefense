using System;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure.StaticData
{
    [Serializable]
    public class EnemySpawnPoint
    {
        public Vector3 Position;

        public EnemySpawnPoint(Vector3 position)
        {
            Position = position;
        }
    }
}