﻿using Assets.Source.Scripts.Infrustructure.Data;

namespace Assets.Source.Scripts.Infrustructure.Services.Progress
{
    public interface IProgressService: IService
    {
        SceneProgress SceneProgress { get; set; }
    }
}