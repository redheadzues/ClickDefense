using UnityEngine;

public class Wallet : MonoBehaviour
{
    private double _balance;

    public bool TrySpendMoney(double value)
    {
        if((_balance - value) > 0)
        {
            _balance -= value;
            return true;
        }
        else
            return false;
    }

    public void AddMoney(double value)
    {
        _balance += value;
    }

}
