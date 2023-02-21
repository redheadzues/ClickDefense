namespace Assets.Source.Scripts.GameOver
{
    public class GameOverer
    {
        private LivesCounter _counter;

        public GameOverer(LivesCounter counter)
        {
            _counter = counter;
            _counter.Changed += OnlivesChanged;
        }

        private void OnlivesChanged(int liveCount)
        {
            if (liveCount <= 0)
                StopGame();
        }

        private void StopGame()
        {
            
        }
    }
}