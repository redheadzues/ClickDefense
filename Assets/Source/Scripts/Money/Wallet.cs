using System;
using Saver;
using NumbersForIdle;
using UnityEngine;

namespace Money
{
    public class Wallet : MonoBehaviour
    {
        private SaverMoney _saverMoney = new SaverMoney();
        private IdleNumber _balance;

        public IdleNumber Balance => _balance;
        public event Action<IdleNumber> BalanceChanged;

        private void Start()
        {
            _balance = _saverMoney.ReadValue();
            BalanceChanged?.Invoke(_balance);
        }

        public bool TrySpendMoney(IdleNumber value)
        {
            if ((_balance - value) >= 0)
            {
                BalanceChange(value * -1);
                return true;
            }
            else
                return false;
        }

        public void AddMoney(IdleNumber value)
        {
            BalanceChange(value);
        }

        private void BalanceChange(IdleNumber value)
        {
            _balance += value;
            _saverMoney.WriteValue(_balance);
            BalanceChanged?.Invoke(_balance);
        }
    }
}