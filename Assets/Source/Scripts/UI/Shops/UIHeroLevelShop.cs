using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHeroLevelShop : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private PlayerLevel _playerLevel;
    [SerializeField] private PlayerCostCalculator _playerCost;
    [SerializeField] private Button _buttonUpgrade;
    [SerializeField] private TMP_Text _textCost;

    private void OnEnable()
    {
        _buttonUpgrade.onClick.AddListener(OnButtonUpgradeClick);
    }

    private void Start()
    {
        FillButtonUpgrade();
    }

    private void OnDisable()
    {
        _buttonUpgrade.onClick.RemoveListener(OnButtonUpgradeClick);
    }

    private void OnButtonUpgradeClick()
    {
        if (_wallet.TrySpendMoney(_playerCost.CurrentLevelUpgradeCost) == true)
        {
            _playerLevel.Increase();
            FillButtonUpgrade();
        }
    }

    private void FillButtonUpgrade()
    {
        _textCost.text = "Улучшить" + _playerCost.CurrentLevelUpgradeCost.ToString();
    }
}
