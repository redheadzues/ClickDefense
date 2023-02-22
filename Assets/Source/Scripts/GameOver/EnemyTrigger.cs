using UnityEngine;

namespace Assets.Source.Scripts.GameOver
{
    //Using EnemyTrigger Layer for collision

    public class EnemyTrigger : MonoBehaviour
    {
        private LivesCounter _counter;

        public void Construct(LivesCounter counter)
        {
            _counter = counter;
        }

        private void OnTriggerEnter(Collider other)
        {
            _counter.RemoveLive();
        }
    }
}
