using Assets.Source.Scripts.Enemies;

namespace Assets.Source.Scripts.Infrustructure.Services.Reward
{
    public interface IRewarder : IService
    {
        void CleanUp();
        void Register(IEnemy enemy);
    }
}