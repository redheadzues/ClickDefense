using UnityEngine;
using Player;
using NumbersForIdle;

public class PlayerUnity : MonoBehaviour
{
    private static Parametrs _playerParametrs = new Parametrs();
    private DamageCalculator _damageCalculator = new DamageCalculator(_playerParametrs);
    private CostCalculator _costCalculator = new CostCalculator(_playerParametrs);

    public Parametrs Parametrs => _playerParametrs;
    public IdleNumber Cost => _costCalculator.CurrentUpgradePrice;
    public IdleNumber Damage => _damageCalculator.GetValue();

    public void Awake()
    {
        _playerParametrs.LoadSaves();
    }
}