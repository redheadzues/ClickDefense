using System;

namespace Assets.Source.Scripts.CharactersComponent
{
    public interface IHealth
    {
        int Value { get; }

        event Action<int> HealthChanged;
    }
}