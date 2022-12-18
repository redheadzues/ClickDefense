using Saver;
using System;

namespace Player
{
    public class PlayerLevel : IDataChangedNotifyer
    {
        private SaverPlayerLevel _saverLevel;
        private int _value;

        public event Action DataChanged;

        public int Value => _value;

        public PlayerLevel()
        {
            _saverLevel = new SaverPlayerLevel();
            _value = _saverLevel.ReadValue();
        }

        public void Increase()
        {
            _value++;
            DataChanged?.Invoke();
            _saverLevel.WtiteValue(_value);
        }
    }
}