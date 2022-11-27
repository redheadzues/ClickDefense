using UnityEngine;
using TowerSaver;

public abstract class Tower : MonoBehaviour, ITowerData
{
    [SerializeField] protected TowerAttaker Attacker;
    [SerializeField] private string _name;

    private float _range = 3;
    private float _attackRate = 1;
    private double _damage = 5;
    private int _level = 1;
    private SaverTower _saverTower;

    public float Range => _range;

    public float AttackRate => _attackRate;

    public double Damage => _damage;

    private void Awake()
    {
        _saverTower = new SaverTower(_name);
        ReadSaverData();
    }

    public void Initialize(BulletSpawner bulletSpawner)
    {
        Attacker.Initialize(bulletSpawner);
    }

    public void IncreaseRange(float value)
    {
        _range += value;
        _saverTower.WriteRange(_range);
    }

    public void IncreaseAttackRate(float value)
    {
        _attackRate += value;
        _saverTower.WriteRange(_attackRate);
    }

    public void IncreaseDamage(double value)
    {
        _damage += value;
        _saverTower.WriteDamage(_damage);
    }

    public void IncreaseLevel()
    {
        _level++;
        _saverTower.WriteLevel(_level);
    }

    private void ReadSaverData()
    {
        _range = _saverTower.ReadRange(_range);
        _attackRate = _saverTower.ReadAttackRate(_attackRate);
        _damage = _saverTower.ReadDamage(_damage);
        _level = _saverTower.ReadLevel(_level);
        transform.position = _saverTower.ReadPosition(transform.position);
    }
}

namespace TowerSaver
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
            SetVector3(_keyTowerPosition + name, point);
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


