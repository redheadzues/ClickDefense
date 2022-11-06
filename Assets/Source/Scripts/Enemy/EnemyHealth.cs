using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int _value;

    public int Value => _value;

    public event Action<int> ValueChanged;

    public void TakeDamage(int damage)
    {
        if(damage > 0)
        {
            _value -= damage;
            ValueChanged?.Invoke(_value);
        }

        TryDie();
    }

    private void TryDie()
    {
        if (_value <= 0)
            Die();
    }

    private void Die()
    {

    }    
}
