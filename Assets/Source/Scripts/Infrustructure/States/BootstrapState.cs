namespace Assets.Source.Scripts.Infrustructure.States
{
    internal class BootstrapState : IState
    {
        private GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load("Init", OnLevelLoaded);
        }

        public void Exit()
        {
        }

        private void OnLevelLoaded()
        {
            _gameStateMachine.Enter<LoadLevelState>();
        }
    }
}