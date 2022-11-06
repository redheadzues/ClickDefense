using System;

public interface IDamageable
{
    void TakeDamage(int damage);

    public int Value {get;}

    public event Action<int> ValueChanged;
}
