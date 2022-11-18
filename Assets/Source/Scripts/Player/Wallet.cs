using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private double _balance;

    public event Action<double> BalanceChanged;

    public bool TrySpendMoney(double value)
    {
        if((Math.Round(_balance) - Math.Round(value)) >= 0)
        {
            _balance -= value;
            BalanceChanged?.Invoke(_balance);
            return true;
        }
        else
            return false;
    }

    public void AddMoney(double value)
    {
        _balance += value;
        BalanceChanged?.Invoke(_balance);
    }

}
