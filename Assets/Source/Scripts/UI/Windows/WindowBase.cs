using UnityEngine;

namespace Assets.Source.Scripts.UI.Windows
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
