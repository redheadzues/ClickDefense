using Assets.Source.Scripts.Enemies;
using Assets.Source.Scripts.Infrustructure.Services.Wallets;
using System.Collections.Generic;

namespace Assets.Source.Scripts.Infrustructure.Services.Reward
{
    public class Rewarder : IRewarder
    {
        private List<IEnemy> _damageables = new List<IEnemy>();
        private readonly IWalletHolder _walletHolder;

        public Rewarder(IWalletHolder walletHolder)
        {
            _walletHolder = walletHolder;
        }

        public void Register(IEnemy enemy)
        {
            if (_damageables.Contains(enemy) == false)
            {
                _damageables.Add(enemy);
                enemy.Died += OnDied;
            }
        }

        public void CleanUp()
        {
            foreach (IEnemy damageable in _damageables)
                damageable.Died -= OnDied;
        }

        private void OnDied(IEnemy enemy)
        {
            _walletHolder.SilverWallet.AddMoney(enemy.Reward);
        }
    }
}
