using System;
using TMPro;
using UnityEngine;

public class UIHeroDamage : MonoBehaviour
{
    [SerializeField] private ClickDamageCalculator _clickDamage;
    [SerializeField] private TMP_Text _textHeroDamage;

    private void OnEnable()
    {
        _clickDamage.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _clickDamage.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(double value)
    {
        _textHeroDamage.text = "Урон героя: " + Math.Round(value).ToString();
    }
}
