using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private Transform[] _points;

    private void Start()
    {
        int countCopmonents = GetComponentsInChildren<Transform>().Length;
        _points = new Transform[countCopmonents - 1];
        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = GetComponentsInChildren<Transform>()[i + 1];
        }
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        float countSeconds = 2;
        int numberPoint;

        while (true)
        {
            numberPoint = Random.Range(0, _points.Length);
            Instantiate(_enemy, _points[numberPoint]);
            yield return new WaitForSeconds(countSeconds);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            collision.GetComponent<Enemy>().DeleteSelf();
        }
    }
}
