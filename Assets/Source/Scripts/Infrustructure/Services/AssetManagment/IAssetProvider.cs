using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure.Services.AssetManagment
{
    public interface IAssetProvider : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Transform parent);
    }
}