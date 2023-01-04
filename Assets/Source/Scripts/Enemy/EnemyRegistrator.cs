using UnityEngine;

[RequireComponent(typeof(IDamageable))]
public class EnemyRegistrator : MonoBehaviour
{
    private void Awake()
    {
        IDamageable damageable = GetComponent<IDamageable>();
        FindObjectOfType<GoldRewarder>().Add(damageable);
    }
}
