using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private Transform _thief;
    [SerializeField] private Transform _house;
    [SerializeField] private float _speed;

    private Vector2 _target;
    private Vector2 _exit;

    private void Start()
    {
       _target = new Vector2(_house.position.x, _thief.position.y);
       _exit = _thief.position;
    }

    private void Update()
    {
        Move(_thief.position, _target);
        TryReturn();
    }

    private void Move(Vector2 current, Vector2 target)
    {
        _thief.position = Vector2.MoveTowards(current, target, _speed * Time.deltaTime);
    }

    private void TryReturn ()
    {
        if (_thief.position.x == _house.position.x)
        {
            _thief.Rotate(Vector3.up, 180);
            _speed *= 2;
            _target = _exit;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<House>())
        {
            _speed /= 2;
        }
    }
}
