using NumbersForIdle;
using System;

public interface IWallet 
{
    bool TrySpendMoney(IdleNumber value);
    void AddMoney(IdleNumber value);

    event Action<IdleNumber> BalanceChanged;
}
