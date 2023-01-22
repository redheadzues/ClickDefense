using Assets.Source.Scripts.Infrustructure.Services.SaveLoad;

namespace Assets.Source.Scripts.Infrustructure.Services.Progress
{
    public interface ISaveProgress
    {
        void Register(ISaveLoadService saveLoad);
        void SaveProgress(IProgressService progress);
        void LoadProgress(IProgressService progress);
    }
}
