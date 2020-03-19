using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Door : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;

    private Coroutine _changeVolume;

    public void OnAlarm()
    {
        _alarm.Play();
        _changeVolume = StartCoroutine(ChangeVolume());
    }

    public void OffAlarm()
    {
        _alarm.Stop();
        if (_changeVolume != null)
        {
            StopCoroutine(_changeVolume);
        }
    }

    private IEnumerator ChangeVolume()
    {
        float angle = 0;
        while (true)
        {
            _alarm.volume = Mathf.Abs(Mathf.Sin(angle));
            angle += 0.01f;
            yield return null;
        }
    }
}
