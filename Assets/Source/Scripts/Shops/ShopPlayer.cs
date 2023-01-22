using NumbersForIdle;
using UnityEngine;
using Money;

namespace Shops
{
    public class ShopPlayer : MonoBehaviour
    {
        //[SerializeField] private PlayerUnity _player;
        //[SerializeField] private SilverWallet _wallet;
        //[SerializeField] private UIViewPlayerLevelUpgrade _increaseLevelView;

        //private void OnEnable()
        //{
        //    _increaseLevelView.ButtonClicked += OnButtonIncreaseLevelClicked;
        //    _wallet.BalanceChanged += OnBalanceChanged;
        //}

        //private void OnDisable()
        //{
        //    _increaseLevelView.ButtonClicked -= OnButtonIncreaseLevelClicked;
        //    _wallet.BalanceChanged -= OnBalanceChanged;
        //}

        //private void Start()
        //{
        //    _increaseLevelView.DisplayCurrentData(_player.Cost.ToString());
        //}

        //private bool IncreaseLevel()
        //{
        //    if (_wallet.TrySpendMoney(_player.Cost))
        //    {
        //        _player.Parametrs.IncreaseLevel();
        //        return true;
        //    }
        //    else
        //        return false;
        //}

        //private void OnButtonIncreaseLevelClicked()
        //{
        //    if (IncreaseLevel())
        //        _increaseLevelView.DisplayCurrentData(_player.Cost.ToString());
        //}

        //private void OnBalanceChanged(IdleNumber balance)
        //{
        //    bool isAvailable = balance >= _player.Cost;

        //    _increaseLevelView.SetButtonAvailAbleStatus(isAvailable);
        //}
    }
}


