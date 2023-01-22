using Assets.Source.Scripts.Infrustructure.States;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure
{
    public class GameBootstraper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private Curtain _curtainPrefab;

        private Game _game;

        private void Awake()
        {
            _game = new Game(this, Instantiate(_curtainPrefab));
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }

        public static void Debug(string debug)
        {
            print(debug);
        }
    }
}
