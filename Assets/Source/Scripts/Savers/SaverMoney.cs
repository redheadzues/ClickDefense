namespace Saver
{
    public class SaverMoney : Saver
    {
        private const string _keyMoney = "SavedMoney";

        public void WriteValue(double value)
        {
            SetDouble(_keyMoney, value);
        }

        public double ReadValue()
        {
            return GetDouble(_keyMoney);
        }
    }
}
