using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePickUp : MonoBehaviour
{
    public CountDownTimer counterDwonScript;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            counterDwonScript.IncreaseTime();
            Destroy(gameObject);
        }
    }
}

