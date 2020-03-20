using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Door _door;
   
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Thief>())
        {
            _door.OnAlarm();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<Thief>())
        {
            _door.OffAlarm();
        }
    } 
}
