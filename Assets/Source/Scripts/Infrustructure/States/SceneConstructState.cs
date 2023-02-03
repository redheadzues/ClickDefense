using Assets.Source.Scripts.AbilitiesSystem.Abilities;
using Assets.Source.Scripts.AbilitiesSystem.Factories;
using Assets.Source.Scripts.Infrustructure.Services.ClickListener;
using Assets.Source.Scripts.Infrustructure.Services.Factories;
using Assets.Source.Scripts.Infrustructure.Services.Reward;
using Assets.Source.Scripts.Infrustructure.Services.SaveLoad;
using Assets.Source.Scripts.Infrustructure.Services.StaticData;
using Assets.Source.Scripts.Player;
using Money;

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
        private readonly IStaticDataService _staticData;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IAbilityFactory _abilityFactory;
        private PlayerModel _player;
        private Vawe _vawe;

        public SceneConstructState(
            GameStateMachine gameStateMachine,
            IUIFactory uiFactory,
            Curtain curtain,
            ISaveLoadService saveLoad,
            SilverWallet silverWallet,
            IStaticDataService staticData,
            ICoroutineRunner coroutineRunner,
            IRewarder rewarder,
            IAbilityFactory abilityFactory)
        {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
            _curtain = curtain;
            _saveload = saveLoad;
            _silverWallet = silverWallet;
            _staticData = staticData;
            _coroutineRunner = coroutineRunner;
            _abilityFactory = abilityFactory;

            _clickInformer = new ClickInformer();
            _enemyFactory = new EnemyFactory(_clickInformer, rewarder, staticData);
            _abilityFactory = abilityFactory;
        }

        public void Enter()
        {
            CreatePlayer();
            CreateEnemySpawner();
            CreateUI();
            LoadSceneData();

            _curtain.Hide();
        }

        private void CreateEnemySpawner()
        {
            EnemySpawner spawwner = new(_enemyFactory, _staticData, _coroutineRunner);
            _vawe = new Vawe(spawwner, _saveload);
        }

        private void CreateUI()
        {
            _uiFactory.CreateHud(_player, _silverWallet, _vawe);
        }

        public void Exit()
        {
        }

        private void CreatePlayer()
        {
            Ability ability = _abilityFactory.CreateAbility("TestingAbility");
            _player = new PlayerModel(_saveload, _clickInformer);
            _player.AbilityContainer.AddAbility(ability);
        }

        private void LoadSceneData()
        {
            _saveload.PushLoadedDataToSavers();
        }               
    }
}