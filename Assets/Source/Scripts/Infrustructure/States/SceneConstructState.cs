using Assets.Source.Scripts.Infrustructure.Services.Factories;

namespace Assets.Source.Scripts.Infrustructure.States
{
    public class SceneConstructState : ISimpleState
    {
        private IUIFactory _uiFactory;

        public SceneConstructState(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void Enter()
        {
            _uiFactory.CreateHud();
        }

        public void Exit()
        {
        }
    }
}