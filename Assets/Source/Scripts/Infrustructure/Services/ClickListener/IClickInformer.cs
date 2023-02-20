using Assets.Source.Scripts.AbilitiesSystem;
using Assets.Source.Scripts.CharactersComponent;
using Assets.Source.Scripts.Enemies;
using System;

namespace Assets.Source.Scripts.Infrustructure.Services.ClickListener
{
    public interface IClickInformer : IPausableService
    {
        void Register(ClickReader reader);
        void CleanUp();
        event Action<IDamageable> Clicked;
        event Action<IAbilityTarget> AbilityTargetGeted;
    }
}