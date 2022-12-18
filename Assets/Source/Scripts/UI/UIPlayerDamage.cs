using System;
using TMPro;
using UnityEngine;

public class UIPlayerDamage : MonoBehaviour
{
    [SerializeField] private ClickDamageCalculator _clickDamage;
    [SerializeField] private TMP_Text _textPlayerDamage;

    private void OnEnable()
    {
        //_clickDamage.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        //_clickDamage.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(double value)
    {
        _textPlayerDamage.text = "Урон героя: " + Math.Round(value).ToString();
    }
}
