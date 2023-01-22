using System;

namespace Assets.Source.Scripts.Enemies
{
    public interface IHealth
    {
        int Health { get; }

        event Action<int> HealthChanged;
    }
}