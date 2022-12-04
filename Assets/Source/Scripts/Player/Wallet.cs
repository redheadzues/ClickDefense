using System;
using UnityEngine;
using MoneySaver;

public class Wallet : MonoBehaviour
{
    private SaverMoney _saverMoney = new SaverMoney();

    private double _balance;

    public event Action<double> BalanceChanged;

    private void Start()
    {
        _balance = _saverMoney.ReadValue();
        BalanceChanged?.Invoke(_balance);
    }

    public bool TrySpendMoney(double value)
    {
        if((Math.Round(_balance) - Math.Round(value)) >= 0)
        {
            BalanceChange(-value);
            return true;
        }
        else
            return false;
    }

    public void AddMoney(double value)
    {
        BalanceChange(value);
    }

    private void BalanceChange(double value)
    {
        _balance += value;
        _saverMoney.WriteValue(_balance);
        BalanceChanged?.Invoke(_balance);
    }

}

namespace MoneySaver
{
    public class SaverMoney : Saver
    {
        private const string _keyMoney = "SavedMoney";

        public void WriteValue(double value)
        {
            SetDouble(_keyMoney, value);
        }

        public double ReadValue()
        {
            return GetDouble(_keyMoney);
        }
    }
}

