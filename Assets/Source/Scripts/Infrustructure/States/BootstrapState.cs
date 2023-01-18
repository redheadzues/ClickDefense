namespace Assets.Source.Scripts.Infrustructure.States
{
    internal class BootstrapState : ISimpleState
    {
        private readonly GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load("Init", OnLevelLoaded);
        }

        public void Exit()
        {
        }

        private void OnLevelLoaded()
        {
            _gameStateMachine.Enter<LoadLevelState, string>("Main");
        }

        private void RegisterServices()
        {

        }
    }
}