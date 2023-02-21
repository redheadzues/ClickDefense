using Assets.Source.Scripts.AbilitiesSystem.Components;
using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Source.Scripts.GameOver
{
    public class EnemyTrigger : MonoBehaviour
    {
        private LivesCounter _counter;

        public void Construct(LivesCounter counter)
        {
            _counter = counter;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out AbilityTargetComponent tagContainer))
            {
                if (tagContainer.Tags.Contains(AbilityTag.Enemy))
                {
                    _counter.RemoveLive();
                    tagContainer.gameObject.SetActive(false);
                }
            }
        }
    }
}
