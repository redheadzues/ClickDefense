using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure.Services.AssetManagment
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Instantiate(string path) =>
            Object.Instantiate(Resources.Load<GameObject>(path));
        
        public GameObject Instantiate(string path, Transform parent) =>
            Object.Instantiate(Resources.Load<GameObject>(path), parent);

    }
}
