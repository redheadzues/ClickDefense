using UnityEngine;
using Player;
using NumbersForIdle;
using System;

public class PlayerUnity : MonoBehaviour
{
    private Parametrs _playerParametrs;
    private DamageCalculator _damageCalculator;
    private CostCalculator _costCalculator;

    public IDataChangedNotifyer ChangedNotifyer => _playerParametrs;
    public IPlayerData PlayerData => _playerParametrs;
    public IPlayerUpgrader Upgrader => _playerParametrs;
    public IdleNumber Cost => _costCalculator.GetValue();
    public IdleNumber Damage => _damageCalculator.GetValue();

    public Action DataChanged;

    public void Awake()
    {
        _playerParametrs = new Parametrs();
        _damageCalculator = new DamageCalculator(_playerParametrs, _playerParametrs);
        _costCalculator = new CostCalculator(_playerParametrs);

        _playerParametrs.DataChanged += DataChanged;
    }
}