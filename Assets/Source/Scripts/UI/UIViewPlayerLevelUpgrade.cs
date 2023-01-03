using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIViewPlayerLevelUpgrade : MonoBehaviour
{
    [SerializeField] private Button _buttonIncreaseLevel;
    [SerializeField] private TMP_Text _textCost;

    public event Action ButtonClicked;

    private void OnEnable()
    {
        _buttonIncreaseLevel.onClick.AddListener(OnButtonIncreaseLevelClicked);
    }

    private void OnDisable()
    {
        _buttonIncreaseLevel.onClick.RemoveListener(OnButtonIncreaseLevelClicked);
    }

    public void DisplayCurrentData(string cost)
    {
        _textCost.text = "Улучшить: " + cost;
    }

    public void SetButtonAvailAbleStatus(bool isAvailable)
    {
        _buttonIncreaseLevel.enabled = isAvailable;
    }

    private void OnButtonIncreaseLevelClicked()
    {
        ButtonClicked?.Invoke();
    }


}
