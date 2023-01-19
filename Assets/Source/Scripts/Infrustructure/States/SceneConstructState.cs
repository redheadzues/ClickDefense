using Assets.Source.Scripts.Infrustructure.Services;
using Assets.Source.Scripts.Infrustructure.Services.ClickListener;
using Assets.Source.Scripts.Infrustructure.Services.Factories;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure.States
{
    public class SceneConstructState : ISimpleState
    {
        private readonly IUIFactory _uiFactory;
        private Curtain _curtain;

        public SceneConstructState(IUIFactory uiFactory, Curtain curtain)
        {
            _uiFactory = uiFactory;
            _curtain = curtain;
        }

        public void Enter()
        {
            _uiFactory.CreateHud();
            _curtain.Hide();
        }

        public void Exit()
        {
        }
    }
}