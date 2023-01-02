using Saver;

namespace GameLevel
{
    public class Level
    {
        private int _level;
        private SaverLevel _saverLevel;

        public int Value => _level;

        public Level()
        {
            _saverLevel = new SaverLevel();
            _level = _saverLevel.ReadValue();
        }


        public void Increase()
        {
            _level++;
            _saverLevel.WriteValue(_level);
        }
    }
}
