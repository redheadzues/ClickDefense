using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerAttaker _attacker;

    public void Initialize(BulletSpawner bulletSpawner)
    {
        _attacker.Initialize(bulletSpawner);
    }
}
