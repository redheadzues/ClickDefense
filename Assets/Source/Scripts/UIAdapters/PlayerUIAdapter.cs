using NumbersForIdle;
using Shops;
using UnityEngine;

public class PlayerUIAdapter : MonoBehaviour
{
    [SerializeField] private UIViewPlayerLevelUpgrade _increaseLevelView;

    private IBalanceNotifyer _balanceChangedNotifyer;
    private ShopPlayer _shop;

    private void Construct(ShopPlayer shop, IBalanceNotifyer balanceChanger)
    {
        _shop = shop;
        _balanceChangedNotifyer = balanceChanger;
        _balanceChangedNotifyer.BalanceChanged += OnBalanceChanged;
    }

    private void OnEnable()
    {
        _increaseLevelView.ButtonClicked += OnButtonIncreaseLevelClicked;
    }

    private void OnDisable()
    {
        _increaseLevelView.ButtonClicked -= OnButtonIncreaseLevelClicked;
        _balanceChangedNotifyer.BalanceChanged -= OnBalanceChanged;
    }

    private void OnButtonIncreaseLevelClicked()
    {
        if (_shop.IncreaseLevel())
            _increaseLevelView.DisplayCurrentData(_shop.Price.ToString());
    }

    private void OnBalanceChanged(IdleNumber balance)
    {
        bool isAvailable = balance >= _shop.Price;

        _increaseLevelView.SetButtonAvailAbleStatus(isAvailable);
    }
}
