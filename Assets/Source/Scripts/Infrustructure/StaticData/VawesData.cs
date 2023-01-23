using System;
using System.Collections.Generic;

namespace Assets.Source.Scripts.Infrustructure.StaticData
{
    [Serializable]
    public class VawesData
    {
        public List<VaweCell> VaweCell;
    }

    [Serializable]
    public class VaweCell
    {
        public EnemyTypeId Type;
        public int EnemyLevel;
        public int Count;
    }
}