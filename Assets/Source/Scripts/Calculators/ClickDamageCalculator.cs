using System;
using UnityEngine;

public class ClickDamageCalculator : MonoBehaviour
{
    ////[SerializeField] private PlayerLevel _playerLevel;
    //[SerializeField] private CriticalStrikeCalculator _critical;

    //private double _damage;

    //public event Action<double> ValueChanged;

    //private void OnEnable()
    //{
    //    _playerLevel.Increased += CalculateDamage;
    //}

    //private void Start()
    //{
    //    _damage = 1;
    //    ValueChanged?.Invoke(_damage);
    //}

    //private void OnDisable()
    //{
    //    _playerLevel.Increased -= CalculateDamage;
    //}

    //public double GetValue()
    //{
    //    return _damage * _critical.GetValue();
    //}

    //private void CalculateDamage()
    //{
    //    _damage = _playerLevel.Value;
    //    ValueChanged?.Invoke(_damage);
    //}
}
