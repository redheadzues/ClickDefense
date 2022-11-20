using System.Collections;
using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private IDamageable _target;
    private double _damage;

    private void Initialize(IDamageable target, double damage)
    {
        _target = target;
        _damage = damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out IDamageable damageable))
            if (damageable == _target)
            {
                _target.TakeDamage(_damage);
                gameObject.SetActive(false);
            }
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.Position, _speed * Time.deltaTime);
    }

    private IEnumerator OnMove()
    {
        while(gameObject.activeSelf == true)
        {
            MoveToTarget();
            yield return new WaitForSeconds(0.01f);
        }
    }
}
