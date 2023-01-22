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

        public void Register(IEnemy damageable)
        {
            if (_damageables.Contains(damageable) == false)
            {
                _damageables.Add(damageable);
                damageable.Died += OnDied;
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
