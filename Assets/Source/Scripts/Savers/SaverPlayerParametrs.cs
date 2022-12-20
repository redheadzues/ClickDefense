namespace Saver
{
    public class SaverPlayerParametrs : Saver
    {
        private const string _keyLevel = "PlayerLevel";
        private const string _keyDamage = "PlayerDamage";
        private const string _keyCriticalChance = "PlayerCriticalChance";
        private const string _keyCriticalMultiplicator = "PlayerCriticalMultiplicator";

        public void WriteLevel(int level)
        {
            SetInt(_keyLevel, level);
        }

        public void WriteDamage(int damage)
        {
            SetInt(_keyDamage, damage);
        }

        public void WriteCriticalChance(float criticalChance)
        {
            SetFloat(_keyCriticalChance, criticalChance);
        }

        public void WriteCriticalMultiplicator(float multiplicator)
        {
            SetFloat(_keyCriticalMultiplicator, multiplicator);
        }

        public int ReadLevel(int defaultValue)
        {
            return GetInt(_keyLevel, defaultValue);
        }

        public int ReadDaamge(int defaultValue)
        {
            return GetInt(_keyDamage, defaultValue);
        }

        public float ReadCriticalChance(float defaultValue)
        {
            return GetFloat(_keyCriticalChance, defaultValue);
        }

        public float ReadCriticalMultiplicator(float defaultValue)
        {
            return GetFloat(_keyCriticalMultiplicator, defaultValue);
        }

    }
}


