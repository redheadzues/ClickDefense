using Assets.Source.Scripts.CharactersComponent;
using UnityEngine;

namespace Assets.Source.Scripts.Enemies
{
    //Using EnemyTrigger Layer for collision

    public class DeathTrigger : MonoBehaviour
    {
        [SerializeField] private Health _health;

        private void OnTriggerEnter(Collider other)
        {
            _health.TakeDamage(_health.Value);
        }
    }
}
