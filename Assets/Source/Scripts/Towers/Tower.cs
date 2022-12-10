using UnityEngine;
using Saver;
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




