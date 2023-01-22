using System;

namespace Assets.Source.Scripts.Infrustructure.Data
{
    [Serializable]
    public class SceneData
    {
        public int PlayerLevel;
        public int SilverAmount;
        public int VaweNumber;

        public SceneData()
        {
            PlayerLevel = 1;
            SilverAmount = 0;
            VaweNumber = 1;
        }

    }
}
