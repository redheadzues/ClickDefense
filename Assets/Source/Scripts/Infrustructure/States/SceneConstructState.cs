using Assets.Source.Scripts.Infrustructure.Services.Factories;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure.States
{
    public class SceneConstructState : ISimpleState
    {
        private readonly IUIFactory _uiFactory;
        private readonly IEnemyFactory _enemyFactory;
        private readonly Curtain _curtain;

        public SceneConstructState(IUIFactory uiFactory, Curtain curtain, IEnemyFactory enemyFactory)
        {
            _uiFactory = uiFactory;
            _curtain = curtain;
            _enemyFactory = enemyFactory;
        }

        public void Enter()
        {
            _uiFactory.CreateHud();
             GameObject.FindObjectOfType<EnemySpawner>().Construct(_enemyFactory);
                        
            _curtain.Hide();
        }

        public void Exit()
        {
        }
    }
}