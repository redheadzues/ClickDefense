using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure.Services.AssetManagment
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Instantiate(string path) =>
            Object.Instantiate(Resources.Load<GameObject>(path));
        
        public GameObject Instantiate(string path, Transform parent) =>
            Object.Instantiate(Resources.Load<GameObject>(path), parent);

        public GameObject Instantiate(string path, Vector3 point, Quaternion quaternion, Transform parrent) =>
            Object.Instantiate(Resources.Load<GameObject>(path), point, quaternion, parrent);

    }
}
