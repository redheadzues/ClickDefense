using Assets.Source.Scripts.Enemies;
using System;

namespace Assets.Source.Scripts.Infrustructure.Services.ClickListener
{
    public interface IClickInformer : IPausableService
    {
        void Register(ClickReader reader);
        void CleanUp();
        event Action<IDamageable> Clicked;
    }
}