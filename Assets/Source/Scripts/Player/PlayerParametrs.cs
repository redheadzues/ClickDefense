using NumbersForIdle;

namespace Player
{
    public class PlayerParametrs
    {
        private int _level;
        private IdleNumber _damage;
        private float _criticalChance;
        private float _criticalMultiplicator;

        public int Level => _level;
        public IdleNumber Damage => _damage;
        public float CriticalChance => _criticalChance; 
        public float CriticalMultiplicator => _criticalMultiplicator;

        public PlayerParametrs()
        {

        }

    }
}