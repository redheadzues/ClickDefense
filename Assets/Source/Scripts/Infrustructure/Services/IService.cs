namespace Assets.Source.Scripts.Infrustructure.Services
{
    public interface IService
    {
    }

    public interface IPausableService : IService
    {
        void Pause();
        void Start();
    }
}