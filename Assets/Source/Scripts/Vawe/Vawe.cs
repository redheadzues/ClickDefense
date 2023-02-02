using Assets.Source.Scripts.Infrustructure.Services.Progress;
using Assets.Source.Scripts.Infrustructure.Services.SaveLoad;
using System;

public class Vawe : ISaveProgress
{
    private readonly EnemySpawner _spawner;
    private readonly ISaveLoadService _saveLoad;
    private int _number;

    public int Number => _number;
    public event Action Finished;
    public event Action<int> Started;

    public Vawe(EnemySpawner spawner, ISaveLoadService saveLoad)
    {
        _spawner = spawner;
        _saveLoad = saveLoad;
        _spawner.Finished += OnVaweFinished;
    }

    private void OnVaweFinished()
    {
        _saveLoad.SaveProgress();
    }

    public void StartNewVawe()
    {
        _number++;
        _spawner.StartNewVawe(_number);
        Started?.Invoke(_number);
    }

    public void Register(ISaveLoadService saveLoad)
    {
        saveLoad.Register(this);
    }

    public void SaveProgress(IProgressService progress)
    {
        progress.PlayerProgress.SceneData.VaweNumber = _number;
    }

    public void LoadProgress(IProgressService progress)
    {
        _number = progress.PlayerProgress.SceneData.VaweNumber;
    }
}
