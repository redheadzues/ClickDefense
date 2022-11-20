using System;
using UnityEngine;

public interface IDamageable
{
    void TakeDamage(double damage);

    public double Value {get;}
    public Vector3 Position { get; }

    public event Action<double> ValueChanged;
    public event Action<double> Died;
}
