using Money;
using UnityEngine;
using NumbersForIdle;
using System.Collections.Generic;

public class GoldRewarder : MonoBehaviour
{
    [SerializeField] private SilverWallet _wallet;

    private float _enemyHpMultiplicator = 0.06f;
    private List<IDamageable> _damageables = new List<IDamageable>();

    private void OnDisable()
    {
        foreach (IDamageable damageable in _damageables)
            damageable.Died -= OnDied;
    }

    public void Add(IDamageable damageable)
    {
        if(_damageables.Contains(damageable) == false)
        {
            _damageables.Add(damageable);
            damageable.Died += OnDied;
        }
    }

    private void OnDied(IDamageable damageable)
    {
        IdleNumber reward = damageable.StartValue * _enemyHpMultiplicator;

        if (reward < 1)
            _wallet.AddMoney(new IdleNumber(1));
        else
            _wallet.AddMoney(reward);
    }
}
