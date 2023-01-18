namespace Assets.Source.Scripts.Infrustructure.States
{
    public interface ISimpleState : IState
    {
        void Enter();
    }

    public interface IPayLoadedState<TPayLoad> : IState
    {
        void Enter(TPayLoad payLoad);
    }

    public interface IState
    {
        void Exit();
    }
}