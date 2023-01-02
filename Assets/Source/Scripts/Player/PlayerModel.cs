using UnityEngine;
using Player;
using NumbersForIdle;

public class PlayerModel : MonoBehaviour
{
    private Wallet _wallet;
    private Parametrs _playerParametrs;
    private DamageCalculator _damageCalculator;
    private CostCalculator _costCalculator;
    private Upgrader _upgrader;


    public IWallet Wallet => _wallet;
    public IDataChangedNotifyer Parametrs => _playerParametrs;
    public IPlayerUpgrader Upgrader => _upgrader;
    public IdleNumber Cost => _costCalculator.GetValue();
    public IdleNumber Damage => _damageCalculator.GetValue();

    public void Awake()
    {
        _wallet = new Wallet();
        _playerParametrs = new Parametrs();
        _damageCalculator = new DamageCalculator(_playerParametrs, _playerParametrs);
        _costCalculator = new CostCalculator(_playerParametrs);
        _upgrader = new Upgrader(_playerParametrs, _costCalculator, _wallet);
    }
}