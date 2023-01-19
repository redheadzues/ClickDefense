using Assets.Source.Scripts.Infrustructure.States;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure
{
    public class GameBootstraper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private Curtain _curtain;

        private Game _game;

        private void Awake()
        {
            _game = new Game(this, _curtain);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}
