using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure
{
    public class GameRunner : MonoBehaviour
    {
        public GameBootstraper BootstraperPrefab;

        private void Awake()
        {
            GameBootstraper bootstrapper = FindObjectOfType<GameBootstraper>();

            if (bootstrapper == null)
                Instantiate(BootstraperPrefab);

        }
    }
}
