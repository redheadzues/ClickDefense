namespace Assets.Source.Scripts.Infrustructure.Services.Reward
{
    public interface IRewarder : IService
    {
        void CleanUp();
        void RegisterEnemy(IDamageable damageable);
    }
}