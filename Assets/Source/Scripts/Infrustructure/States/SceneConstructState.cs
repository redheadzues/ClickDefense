using Assets.Source.Scripts.Infrustructure.Services.ClickListener;
using Assets.Source.Scripts.Infrustructure.Services.Factories;
using Assets.Source.Scripts.Infrustructure.Services.SaveLoad;
using Assets.Source.Scripts.Player;
using Money;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure.States
{
    public class SceneConstructState : ISimpleState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IUIFactory _uiFactory;
        private readonly IEnemyFactory _enemyFactory;
        private readonly ISaveLoadService _saveload;
        private readonly Curtain _curtain;
        private readonly SilverWallet _silverWallet;
        private readonly IClickInformer _clickInformer;
        private PlayerModel _player;
        

        public SceneConstructState(
            GameStateMachine gameStateMachine,
            IUIFactory uiFactory, 
            Curtain curtain, 
            IEnemyFactory enemyFactory, 
            ISaveLoadService saveLoad, 
            SilverWallet silverWallet, 
            IClickInformer clickInformer)
        {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
            _curtain = curtain;
            _enemyFactory = enemyFactory;
            _saveload = saveLoad;
            _silverWallet = silverWallet;
            _clickInformer = clickInformer;
        }

        public void Enter()
        {
            CreatePlayer();
            CreateUI();
            GameObject.FindObjectOfType<EnemySpawner>().Construct(_enemyFactory);

            LoadSceneData();

            _curtain.Hide();
        }

        private void CreateUI()
        {
            _uiFactory.CreateHud(_player);
        }

        public void Exit()
        {
        }
        private void CreatePlayer()
        {
            _player = new PlayerModel(_saveload, _silverWallet, _clickInformer);
        }

        private void LoadSceneData()
        {
            _saveload.PushLoadedDataToSavers();
        }               
    }
}