using NumbersForIdle;

namespace Saver
{
    public class SaverMoney : Saver
    {
        private const string _keyMoney = "SavedMoney";

        public void WriteValue(IdleNumber value)
        {
            SetIdleNumber(_keyMoney, value);
        }

        public IdleNumber ReadValue()
        {
            IdleNumber defaultValue = new(0);
            return GetIdleNumber(_keyMoney, defaultValue);
        }
    }
}
