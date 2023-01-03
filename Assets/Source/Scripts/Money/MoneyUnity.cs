using Money;
using UnityEngine;

public class MoneyUnity : MonoBehaviour
{
    private Wallet _wallet;

    public IWallet Wallet => _wallet;

    private void Awake()
    {
        _wallet = new Wallet();
    }
}
