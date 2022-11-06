using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Start()
    {
        StartCoroutine(OnMove());
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
