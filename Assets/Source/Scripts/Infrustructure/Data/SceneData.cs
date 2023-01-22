using System;

namespace Assets.Source.Scripts.Infrustructure.Data
{
    [Serializable]
    public class SceneData
    {
        public int PlayerLevel;
        public int SilverAmount;

        public SceneData(int level)
        {
            PlayerLevel = level;
        }

    }
}
