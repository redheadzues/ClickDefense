using UnityEngine;

public class BulletSpawner : ObjectsPool
{
    [SerializeField] private TowerBullet _template;

    private void Awake()
    {
        InitializePool<TowerBullet>(_template);
    }

    public void Spawn(Vector3 spawnPoint, IDamageable target, double damage)
    {
        if(TryGetObject<TowerBullet>(out TowerBullet bullet) == true)
        {
            bullet.transform.position = spawnPoint;
            bullet.gameObject.SetActive(true);
            bullet.Initialize(target, damage);
        }

    }
}
