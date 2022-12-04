using UnityEngine;
using TowerSaver;
using System;

public abstract class Tower : MonoBehaviour, ITowerData
{
    [SerializeField] private string _name;
    [SerializeField] private int _rank;

    private float _baseRange = 3;
    private float _baseAttackRate = 1;
    private double _baseDamage = 5;
    private int _level = 1;

    private SaverTower _saverTower;

    public float Range => _baseRange;

    public float AttackRate => _baseAttackRate;

    public double Damage => _baseDamage;

    public int Level => _level;

    public int Rank => _rank;

    public event Action LevelIncreased;

    private void Awake()
    {
        _saverTower = new SaverTower(_name);
        ReadSaverData();
    }

    protected void IncreaseRange(float value)
    {
        _baseRange += value;
        _saverTower.WriteRange(_baseRange);
        IncreaseLevel();
    }

    protected void IncreaseAttackRate(float value)
    {
        _baseAttackRate += value;
        _saverTower.WriteRange(_baseAttackRate);
        IncreaseLevel();
    }

    protected void IncreaseDamage(double value)
    {
        _baseDamage += value;
        _saverTower.WriteDamage(_baseDamage);
        IncreaseLevel();
    }

    private void IncreaseLevel()
    {
        _level++;
        LevelIncreased?.Invoke();
        _saverTower.WriteLevel(_level);
    }

    private void ReadSaverData()
    {
        _baseRange = _saverTower.ReadRange(_baseRange);
        _baseAttackRate = _saverTower.ReadAttackRate(_baseAttackRate);
        _baseDamage = _saverTower.ReadDamage(_baseDamage);
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


