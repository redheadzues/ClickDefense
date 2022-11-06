using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int _value;

    public void TakeDamage(int damage)
    {
        if(damage > 0)
            _value -= damage;

        print("ouch");

        TryDie();
    }

    private void TryDie()
    {
        if (_value <= 0)
            Die();
    }

    private void Die()
    {

    }    
}
