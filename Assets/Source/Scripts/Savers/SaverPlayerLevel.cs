namespace Saver
{
    public class SaverPlayerLevel : Saver
    {
        private const string _keyLevel = "SavedPlayerLevel";
        private const int _defaultPlayerLevel = 1;

        public void WtiteValue(int level)
        {
            SetInt(_keyLevel, level);
        }

        public int ReadValue()
        {
            return GetInt(_keyLevel, _defaultPlayerLevel);
        }
    }
}


