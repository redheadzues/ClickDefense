namespace Assets.Source.Scripts.Infrustructure.States
{
    public class LoadLevelState : IPayLoadedState<string>
    {
        private GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName);
        }

        public void Exit()
        {
        }
    }
}