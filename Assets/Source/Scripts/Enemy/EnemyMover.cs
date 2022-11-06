using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        StartMove();
    }

    private void StartMove()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(OnMove());
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position-Vector3.right, _speed * Time.deltaTime);
    }

    private IEnumerator OnMove()
    {
        while(true)
        {
            Move();
            
            yield return new WaitForSeconds(0.01f);
        }
    }
}
