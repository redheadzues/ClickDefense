using System;
using UnityEngine;

public interface IDamageable
{
    void TakeDamage(int damage);

    public int Value {get;}
    public int StartValue { get; }
    public Vector3 Position { get; }

    public event Action<int> ValueChanged;
    public event Action<IDamageable> Died;
}
