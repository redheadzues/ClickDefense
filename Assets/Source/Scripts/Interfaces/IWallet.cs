using NumbersForIdle;
using System;

public interface IWallet 
{
    public IdleNumber Balance { get; }

    event Action<IdleNumber> BalanceChanged;
    bool TrySpendMoney(IdleNumber value);
    void AddMoney(IdleNumber value);

}
