using Assets.Source.Scripts.Infrustructure.Services;
using Assets.Source.Scripts.Infrustructure.States;

namespace Assets.Source.Scripts.Infrustructure
{
    public class Game
    {
        public GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, Curtain curtain)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), new AllServices(), curtain);
        }
    }
}
