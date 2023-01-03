using NumbersForIdle;
using System;

interface IBalanceNotifyer
{
    public IdleNumber Balance { get; }
    public event Action<IdleNumber> BalanceChanged;
}
