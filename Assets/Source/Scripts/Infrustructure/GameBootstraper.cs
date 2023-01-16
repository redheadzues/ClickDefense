using Assets.Source.Scripts.Infrustructure.States;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure
{
    public class GameBootstraper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game(this);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}
