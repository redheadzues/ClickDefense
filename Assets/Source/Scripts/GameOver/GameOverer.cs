using Assets.Source.Scripts.Infrustructure;
using Assets.Source.Scripts.Infrustructure.Services.Factories;
using Assets.Source.Scripts.Infrustructure.States;
using Assets.Source.Scripts.UI.Windows;

namespace Assets.Source.Scripts.GameOver
{
    public class GameOverer
    {
        private GameStateMachine _gameStateMachine;
        private LivesCounter _counter;
        private IUIFactory _uiFactory;
        private GameOverWindow _window;

        public GameOverer(LivesCounter counter, IUIFactory uiFactory, GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
            _counter = counter;
            _uiFactory = uiFactory;
            _counter.Changed += OnlivesChanged;
        }

        private void OnlivesChanged(int liveCount)
        {
            if (liveCount <= 0)
                StopGame();
        }

        private void StopGame()
        {
            _window = _uiFactory.CreateWindow<GameOverWindow>(WindowId.GameOver);
            _window.ButtonClicked += OnSceneExit;
        }

        private void OnSceneExit()
        {
            _window.ButtonClicked -= OnSceneExit;
            _counter.Changed -= OnlivesChanged;
            _gameStateMachine.Enter<LoadLevelState, string>("MainMenu");
        }
    }
}