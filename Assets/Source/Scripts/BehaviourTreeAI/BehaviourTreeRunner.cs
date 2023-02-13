using UnityEngine;

namespace Assets.Source.Scripts.BehaviourTreeAI
{
    public class BehaviourTreeRunner : MonoBehaviour
    {
        [SerializeField] private BehaviourTree tree;

        private void Start()
        {
            tree = tree.Clone();
        }

        private void Update()
        {
            tree.Update();
        }
    }
}
