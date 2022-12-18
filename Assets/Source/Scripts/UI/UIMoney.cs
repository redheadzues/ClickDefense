//using System;
//using TMPro;
//using UnityEngine;

//public class UIMoney : MonoBehaviour
//{
//    [SerializeField] private Wallet _wallet;
//    [SerializeField] private TMP_Text _textMoney;

//    private void OnEnable()
//    {
//        _wallet.BalanceChanged += OnBalanceChanged;
//    }

//    private void OnDisable()
//    {
//        _wallet.BalanceChanged -= OnBalanceChanged;
//    }

//    private void OnBalanceChanged(double value)
//    {
//        _textMoney.text = "Gold: " +  Math.Round(value).ToString();
//    }
//}
