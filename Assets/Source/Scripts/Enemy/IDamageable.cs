using System;
using UnityEngine;
using NumbersForIdle;

public interface IDamageable
{
    void TakeDamage(IdleNumber damage);

    public IdleNumber Value {get;}
    public IdleNumber StartValue { get; }
    public Vector3 Position { get; }

    public event Action<IdleNumber> ValueChanged;
    public event Action<IDamageable> Killed;
}
