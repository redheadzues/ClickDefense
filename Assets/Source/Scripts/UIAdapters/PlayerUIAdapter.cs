using Shops;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIAdapter : MonoBehaviour
{
    [SerializeField] private UIViewPlayerLevelUpgrade _increaseLevelView;

    private ShopPlayer _shop;
    private IPlayerData _playerData;

    private void OnEnable()
    {
        _increaseLevelView.ButtonClicked += OnButtonIncreaseLevelClicked;
    }

    private void OnDisable()
    {
        _increaseLevelView.ButtonClicked -= OnButtonIncreaseLevelClicked;
    }

    private void OnButtonIncreaseLevelClicked()
    {
        if (_shop.IncreaseLevel())
            print("good");
    }
}
