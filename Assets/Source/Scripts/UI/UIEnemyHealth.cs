using System;
using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class UIEnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemy;
    [SerializeField] private TMP_Text _textHealth;

    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        _enemy.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _enemy.ValueChanged -= OnValueChanged;
    }

    private void Start()
    {
        StartCoroutine(FollowParentEnemy());
    }

    private void OnValueChanged(int health)
    {
        _textHealth.text = health.ToString();
    }

    private void Follow()
    {
        _rectTransform.position = Camera.main.WorldToScreenPoint(_enemy.transform.position);
    }

    private IEnumerator FollowParentEnemy()
    {
        while (true)
        {
            Follow();
            yield return new WaitForSeconds(0.01f);
        }

    }
}
