using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using NumbersForIdle;

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

    public void DisplayCurrentData(IdleNumber cost)
    {
        _textCost.text = "Улучшить: " + cost.ToString();
    }

    private void OnButtonIncreaseLevelClicked()
    {
        ButtonClicked?.Invoke();
    }


}
