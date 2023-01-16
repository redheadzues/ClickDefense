using Infrustructure;

namespace Assets.Source.Scripts.Infrustructure.States
{
    public class LoadLevelState : IState
    {
        private GameStateMachine _gameStateMachine;

        public LoadLevelState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }
    }
}