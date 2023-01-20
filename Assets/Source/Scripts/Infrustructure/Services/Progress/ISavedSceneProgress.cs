namespace Assets.Source.Scripts.Infrustructure.Services.Progress
{
    public interface ISavedSceneProgress
    {
    }

    public interface ISavedPlayerSceneLevelProgress : ISavedSceneProgress
    {
        int Value { get; }
    }
}
