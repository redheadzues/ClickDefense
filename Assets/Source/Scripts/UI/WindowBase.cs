using UnityEngine;

namespace Assets.Source.Scripts.UI
{
    public class WindowBase : MonoBehaviour
    {
        public WindowId WindowId;

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
