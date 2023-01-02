using NumbersForIdle;
using UnityEngine;

public class SpawnHealthRandomizer
{ 
    private float _healthSpred;
    private IGetEnemyHealth _healthGetter;

    private IdleNumber _totalVaweHealth;
    private int _count;

    public SpawnHealthRandomizer(float healthSpred, IGetEnemyHealth healthGetter)
    {
        _healthSpred = healthSpred;
        _healthGetter = healthGetter;
    }

    public void Set(int count = 10)
    {
        _count = count;
        _totalVaweHealth = _healthGetter.EnemyHealthValue * count;
    }

    public bool GetHealthValue(out IdleNumber value)
    {
        if(_count == 1)
        {
            value = _totalVaweHealth;
            return _count-- > 0; 
        }

        float randomHealthMultiplicator = RandomFloat.Next(1 - _healthSpred, 1 + _healthSpred );
        
        value = _totalVaweHealth / _count * randomHealthMultiplicator;
        _totalVaweHealth -= value;

        return _count-- > 0;
    }
}
