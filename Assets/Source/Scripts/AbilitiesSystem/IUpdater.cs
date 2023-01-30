using System;

namespace Assets.Source.Scripts.AbilitiesSystem
{
    public interface IUpdater
    {
        event Action<float> Updated;
    }
}