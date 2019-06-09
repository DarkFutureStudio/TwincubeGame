using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePickUp : MonoBehaviour
{
    public int Timevalue = 5;
    public CountDownTimer counterDwonScript;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            counterDwonScript.IncreaseTime(Timevalue);
            Destroy(gameObject);
        }
    }
}

