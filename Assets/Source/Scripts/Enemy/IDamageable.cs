using System;

public interface IDamageable
{
    void TakeDamage(double damage);

    public double Value {get;}

    public event Action<double> ValueChanged;
}
