namespace Saver
{
    public class SaverVawe : Saver
    {
        private const string _keyVawe = "SavedVawe";

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