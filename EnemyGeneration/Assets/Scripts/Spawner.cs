using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private List<Transform> _points;

    private void Start()
    {
        _points = new List<Transform>();
        GetComponentsInChildren<Transform>(_points);
        _points.RemoveAt(0);
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        float countSeconds = 2;
        int numberPoint;

        while (true)
        {
            numberPoint = Random.Range(0, _points.Count);
            Instantiate(_enemy, _points[numberPoint]);
            yield return new WaitForSeconds(countSeconds);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            collision.GetComponent<Enemy>().Die();
        }
    }
}
