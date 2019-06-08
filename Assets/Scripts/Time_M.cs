using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_M: MonoBehaviour
{
    internal static int deltaTime;
    public int Timevalue = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CountDownTimer.instanvce.ChangeTime(Timevalue);
        }
    }
}

