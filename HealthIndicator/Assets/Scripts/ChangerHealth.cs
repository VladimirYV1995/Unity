using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangerHealth : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _countChangeHealth = 10;
    [SerializeField] private float _countSeconds = 2;

    public void IncreaseHealth()
    {
        StartCoroutine(ChangeHealth(1));
    }

    public void DecreaseHealth()
    {
        StartCoroutine(ChangeHealth(-1));
    }

    private IEnumerator ChangeHealth(int direction)
    {
        float valueChangeHealth = direction * _countChangeHealth;
        float nextSliderValue = _slider.value + valueChangeHealth;

        if (nextSliderValue >= _slider.minValue && nextSliderValue <= _slider.maxValue)
        {
            if (_countSeconds <= 0)
            {
                _countSeconds = 1;
            }

            float speedChangeHealth = valueChangeHealth * Time.deltaTime / _countSeconds;

            while (direction *_slider.value < direction * nextSliderValue)
            {
                _slider.value += speedChangeHealth ;
                yield return null;
            }
        }
        StopCoroutine(ChangeHealth(direction));
    }
}
