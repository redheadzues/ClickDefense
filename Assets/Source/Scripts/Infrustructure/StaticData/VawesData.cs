using System;
using System.Collections.Generic;

namespace Assets.Source.Scripts.Infrustructure.StaticData
{
    [Serializable]
    public class VaweData
    {
        public List<VaweCell> VaweCells;
    }

    [Serializable]
    public class VaweCell
    {
        public EnemyTypeId Type;
        public int Count;
    }
}