using NumbersForIdle;

public interface IWallet 
{
    bool TrySpendMoney(IdleNumber value);
    void AddMoney(IdleNumber value);
}
