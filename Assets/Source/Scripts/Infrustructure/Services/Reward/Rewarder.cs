using Assets.Source.Scripts.Enemies;
using Assets.Source.Scripts.Infrustructure.Services.Wallets;
using System.Collections.Generic;

namespace Assets.Source.Scripts.Infrustructure.Services.Reward
{
    public class Rewarder : IRewarder
    {
        private List<IEnemy> _enemy = new List<IEnemy>();
        private readonly IWalletHolder _walletHolder;

        public Rewarder(IWalletHolder walletHolder)
        {
            _walletHolder = walletHolder;
        }

        public void Register(IEnemy enemy)
        {
            if (_enemy.Contains(enemy) == false)
            {
                _enemy.Add(enemy);
                enemy.Died += OnDied;
            }
        }

        public void CleanUp()
        {
            foreach (IEnemy enemy in _enemy)
                enemy.Died -= OnDied;
        }

        private void OnDied(int reward) =>
            _walletHolder.SilverWallet.AddMoney(reward);
        
    }
}
