using NumbersForIdle;
using Player;

namespace Assets.Source.Scripts.Infrustructure.Services
{
    public interface IPlayerModel : IService
    {
        IdleNumber Cost { get; }
        IdleNumber Damage { get; }
        Parametrs Parametrs { get; }
    }
}