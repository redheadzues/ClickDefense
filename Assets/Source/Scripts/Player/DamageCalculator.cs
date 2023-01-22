using NumbersForIdle;

namespace Player
{
    public class DamageCalculator
    {
        private Level _level;

        public DamageCalculator(Level level)
        {
            _level = level;
        }

        public int GetValue()
        {
            int damage = _level.Value;

            return damage;
        }        
    }
}
