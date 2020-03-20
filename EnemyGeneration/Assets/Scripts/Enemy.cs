using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _enemy;
    [SerializeField] private float _speed = 1;

    private void Update()
    {
        _enemy.Translate(Vector2.up * _speed * Time.deltaTime);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}