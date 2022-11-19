using System;

public interface IDamageable
{
    void TakeDamage(double damage);

    public double Value {get;}
    public float PositionX { get; }

    public event Action<double> ValueChanged;
    public event Action<double> Died;
}
