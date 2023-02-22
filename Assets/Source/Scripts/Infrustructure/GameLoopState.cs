using Assets.Source.Scripts.Infrustructure.States;

namespace Assets.Source.Scripts.Infrustructure
{
    public class GameLoopState : IPayLoadedState<SceneContext>
    {
        private GameStateMachine _gameStateMachine;
        private Curtain _curtain;
        private SceneContext _context;

        public GameLoopState(GameStateMachine gameStateMachine, Curtain curtain)
        {
            _gameStateMachine = gameStateMachine;
            _curtain = curtain;
        }

        public void Enter(SceneContext context)
        {
            _context = context;
            _curtain.Hide();
        }

        public void Exit()
        {
            _context = null;
        }
    }
}