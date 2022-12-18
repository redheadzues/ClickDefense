using System;
using Saver;
using NumbersForIdle;

public class Wallet : IWallet
{
    private SaverMoney _saverMoney;
    private IdleNumber _balance;

    public event Action<IdleNumber> BalanceChanged;

    public Wallet()
    {
        _saverMoney = new SaverMoney();
        _balance = _saverMoney.ReadValue();
        BalanceChanged?.Invoke(_balance);
    }

    public bool TrySpendMoney(IdleNumber value)
    {
        if((_balance - value) >= 0)
        {
            BalanceChange(value * -1);
            return true;
        }
        else
            return false;
    }

    public void AddMoney(IdleNumber value)
    {
        BalanceChange(value);
    }

    private void BalanceChange(IdleNumber value)
    {
        _balance += value;
        _saverMoney.WriteValue(_balance);
        BalanceChanged?.Invoke(_balance);
    }
}