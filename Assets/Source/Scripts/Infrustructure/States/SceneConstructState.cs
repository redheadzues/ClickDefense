using Assets.Source.Scripts.AbilitiesSystem.Abilities;
using Assets.Source.Scripts.AbilitiesSystem.Factories;
using Assets.Source.Scripts.AbilitiesSystem.Tree;
using Assets.Source.Scripts.Infrustructure.Services.ClickListener;
using Assets.Source.Scripts.Infrustructure.Services.Factories;
using Assets.Source.Scripts.Infrustructure.Services.Reward;
using Assets.Source.Scripts.Infrustructure.Services.SaveLoad;
using Assets.Source.Scripts.Infrustructure.Services.StaticData;
using Assets.Source.Scripts.Infrustructure.StaticData;
using Assets.Source.Scripts.Player;
using Assets.Source.Scripts.Shops;
using Money;

namespace Assets.Source.Scripts.Infrustructure.States
{
    public class SceneConstructState : ISimpleState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IUIFactory _uiFactory;
        private readonly ISaveLoadService _saveload;
        private readonly Curtain _curtain;
        private readonly SilverWallet _silverWallet;
        private readonly IStaticDataService _staticData;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IAbilityFactory _abilityFactory;
        private readonly IRewarder _rewarder;
        private IEnemyFactory _enemyFactory;
        private IClickInformer _clickInformer;
        private PlayerModel _player;
        private Vawe _vawe;
        private PlayerAbilityRewarder _playerAbilityRewarder;

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
            _rewarder = rewarder;
            _abilityFactory = abilityFactory;
        }

        public void Enter()
        {
            CreateClickInformer();
            CreatePlayer();
            CreateEnemySpawner();
            CreateUI();
            CreateAbilityRewarder();
            LoadSceneData();

            _curtain.Hide();
        }

        private void CreateClickInformer()
        {
            _clickInformer = new ClickInformer();
        }

        private void CreateAbilityRewarder()
        {
            Branch playerAbilityData = _staticData.ForPlayerAbility();
            _playerAbilityRewarder = new PlayerAbilityRewarder(playerAbilityData, _abilityFactory, _player.AbilityContainer, _vawe, _uiFactory);
        }

        private void CreateEnemySpawner()
        {
            _enemyFactory = new EnemyFactory(_clickInformer, _rewarder, _staticData);
            EnemySpawner spawwner = new(_enemyFactory, _staticData, _coroutineRunner);
            _vawe = new Vawe(spawwner, _saveload);
        }

        private void CreateUI()
        {
            _uiFactory.CreateRootCanvas();
            _uiFactory.CreateHud(_player, _silverWallet, _vawe);
        }

        public void Exit()
        {
        }

        private void CreatePlayer()
        {
            Ability ability = _abilityFactory.Create("a4cfbe1c-4be6-4dc0-8e90-f1085e7feb5411-42-32-04-42-2023-42");
            _player = new PlayerModel(_saveload, _clickInformer);
            _player.AbilityContainer.AddAbility(ability);
        }

        private void LoadSceneData()
        {
            _saveload.PushLoadedDataToSavers();
        }               
    }
}