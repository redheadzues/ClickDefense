using System;

namespace Assets.Source.Scripts.Infrustructure.Data
{
    [Serializable]
    public class GlobalData
    {
        public string SceneName;

        public GlobalData(string initialLevel)
        {
            SceneName = initialLevel;
        }
    }
}