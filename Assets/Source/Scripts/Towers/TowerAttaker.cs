using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class TowerAttaker : MonoBehaviour
{
    [SerializeField] private double _damage;
    [SerializeField] private float _delay;

    private Coroutine _coroutine;

    private List<IDamageable> _targets = new List<IDamageable>();

    private void Attack()
    {
        IDamageable target = GetTarget();
        target.TakeDamage(_damage);

        if(target.Value < 1)
            _targets.Remove(target);
    }

    private IDamageable GetTarget()
    {
        IDamageable target = _targets.OrderBy(t => t.PositionX).First();
           
        return target;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damageable))
        {
            _targets.Add(damageable);

            if (_coroutine == null)
                _coroutine = StartCoroutine(OnAttack());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damageable))
            _targets.Remove(damageable);
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