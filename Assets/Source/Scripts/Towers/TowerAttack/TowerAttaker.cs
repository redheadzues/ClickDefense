using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;

public class TowerAttaker : MonoBehaviour
{
    [SerializeField] private double _damage;
    [SerializeField] private float _delay;
    [SerializeField] private Transform _attackPoint;

    private Coroutine _coroutine;
    private BulletSpawner _bulletSpawner;

    private List<IDamageable> _targets = new List<IDamageable>();


    public void Initialize(BulletSpawner bulletSpawner)
    {
        _bulletSpawner = bulletSpawner;
    }

    private void Attack()
    {
        IDamageable target = GetTarget();
        //_bulletSpawner.Spawn(_attackPoint.position, target, _damage);
    }

    private IDamageable GetTarget()
    {
        IDamageable target = _targets.OrderBy(t => t.Position.x).First();

        return target;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damageable))
        {
            _targets.Add(damageable);
            damageable.Killed += OnKilled;
            
            if (_coroutine == null)
                _coroutine = StartCoroutine(OnAttack());
        }
    }

    private void OnKilled(IDamageable damageable)
    {
        _targets.Remove(damageable);
        damageable.Killed -= OnKilled;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damageable))
        {
            damageable.Killed -= OnKilled;
            _targets.Remove(damageable);
        }
    }

    private IEnumerator OnAttack()
    {
        while (_targets.Count > 0)
        {
            Attack();
            yield return new WaitForSeconds(_delay);
        }

        _coroutine = null;
    }
}