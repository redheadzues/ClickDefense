using System;

namespace Assets.Source.Scripts.Infrustructure.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public GlobalData GlobalData;
        public SceneData SceneData;

        public PlayerProgress(string initialLevel)
        {
            GlobalData = new GlobalData(initialLevel);
            SceneData = new SceneData();
        }
    }
}
