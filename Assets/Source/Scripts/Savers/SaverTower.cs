using Vector3 = UnityEngine.Vector3;

namespace Saver
{
    public class SaverTower : Saver
    {
        private const string _keyTowerRange = "TowerRange";
        private const string _keyTowerAttakRate = "TowerAttackRate";
        private const string _keyTowerDamage = "TowerDamage";
        private const string _keyTowerPosition = "TowerPosition";
        private const string _keyTowerLevel = "TowerLevel";

        private string _name;

        public SaverTower(string name)
        {
            _name = name;
        }

        public void WriteRange(float value)
        {
            SetFloat(_keyTowerRange + _name, value);
        }

        public void WriteAttackRate(float value)
        {
            SetFloat(_keyTowerAttakRate + _name, value);
        }

        public void WriteDamage(double value)
        {
            SetDouble(_keyTowerDamage + _name, value);
        }

        public void WritePositon(Vector3 point)
        {
            SetVector3(_keyTowerPosition + _name, point);
        }

        public void WriteLevel(int level)
        {
            SetInt(_keyTowerLevel + _name, level);
        }

        public float ReadRange(float defaultValue)
        {
            return GetFloat(_keyTowerRange + _name, defaultValue);
        }

        public float ReadAttackRate(float defaultValue)
        {
            return GetFloat(_keyTowerAttakRate + _name, defaultValue);
        }

        public double ReadDamage(double defaultValue)
        {
            return GetDouble(_keyTowerDamage + _name, defaultValue);
        }

        public Vector3 ReadPosition(Vector3 defaultPoint)
        {
            return GetVector3(_keyTowerPosition + _name, defaultPoint);
        }

        public int ReadLevel(int defaultLevel)
        {
            return GetInt(_keyTowerLevel, defaultLevel);
        }
    }
}