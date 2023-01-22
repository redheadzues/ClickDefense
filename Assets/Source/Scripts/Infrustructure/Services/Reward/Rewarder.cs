using Assets.Source.Scripts.Infrustructure.Services.Wallets;
using System.Collections.Generic;

namespace Assets.Source.Scripts.Infrustructure.Services.Reward
{
    public class Rewarder : IRewarder
    {
        private List<IDamageable> _damageables = new List<IDamageable>();
        private readonly IWalletHolder _walletHolder;

        public Rewarder(IWalletHolder walletHolder)
        {
            _walletHolder = walletHolder;
        }

        public void Register(IDamageable damageable)
        {
            if (_damageables.Contains(damageable) == false)
            {
                _damageables.Add(damageable);
                damageable.Died += OnDie;
            }
        }

        public void CleanUp()
        {
            foreach (IDamageable damageable in _damageables)
            {
                damageable.Died -= OnDie;
            }
        }

        private void OnDie(IDamageable damageable)
        {
            _walletHolder.SilverWallet.AddMoney(1);
        }
    }
}
