using Assets.Source.Scripts.Infrustructure.Data;
using Assets.Source.Scripts.Infrustructure.Services.Progress;

namespace Assets.Source.Scripts.Infrustructure.Services.SaveLoad
{
    public interface ISaveLoadService : IService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
        public void Register(ISaveProgress saver);
        public void CleanUp();
        void PushLoadedDataToSavers();
    }
}