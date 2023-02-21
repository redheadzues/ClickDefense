using System;

namespace Assets.Source.Scripts.GameOver
{
    public class LivesCounter
    {
        private int _lives;

        public event Action<int> Changed;

        public LivesCounter(int amount)
        {
            _lives = amount;
        }

        public void AddLive()
        {
            _lives++;
            Changed?.Invoke(_lives);
        }

        public void RemoveLive()
        {
            _lives--;
            Changed?.Invoke(_lives);
        }
    }
}