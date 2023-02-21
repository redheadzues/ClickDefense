using UnityEngine;

namespace Assets.Source.Scripts.GameOver
{
    public class TargetPoint : MonoBehaviour 
    {
        private void Awake()
        {
            Destroy(gameObject);
        }
    }
}
