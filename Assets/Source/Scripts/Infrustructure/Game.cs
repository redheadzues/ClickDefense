namespace Infrustructure
{
    public class Game
    {
        public GameStateMachine GameStateMachine;

        public Game()
        {
            GameStateMachine = new GameStateMachine();
        }
    }
}
