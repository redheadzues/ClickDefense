using Assets.Source.Scripts.Infrustructure.Services.Progress;
using Assets.Source.Scripts.Infrustructure.Services.SaveLoad;
using System;

namespace Money
{
    public class SilverWallet : ISaveProgress
    {
        private int _balance;

        public int Balance => _balance;
        public event Action<int> BalanceChanged;

        public SilverWallet(ISaveLoadService saveLoad)
        {
            Register(saveLoad);
            BalanceChanged?.Invoke(_balance);
        }

        public bool TrySpendMoney(int value)
        {
            if ((_balance - value) >= 0)
            {
                BalanceChange(-value);
                return true;
            }
            else
                return false;
        }

        public void AddMoney(int value)
        {
            BalanceChange(value);
        }

        private void BalanceChange(int value)
        {
            _balance += value;
            BalanceChanged?.Invoke(_balance);
        }

        public void Register(ISaveLoadService saveLoad)
        {
            saveLoad.Register(this);
        }

        public void SaveProgress(IProgressService progress)
        {
            progress.PlayerProgress.SceneData.SilverAmount = _balance;
        }

        public void LoadProgress(IProgressService progress)
        {
            _balance = progress.PlayerProgress.SceneData.SilverAmount;
        }
    }
}