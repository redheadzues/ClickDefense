namespace Saver
{
    public class SaverLevel : Saver
    {
        private const string _keyVawe = "SavedLevel";

        public void WriteValue(int value)
        {
            SetInt(_keyVawe, value);
        }

        public int ReadValue()
        {
            return GetInt(_keyVawe);
        }
    }
}