namespace Assets.Source.Scripts.Infrustructure.Services.ClickListener
{
    public interface IClickListener : IPausableService
    {
        void Register(ClickReader reader);
        void CleanUp();
    }
}