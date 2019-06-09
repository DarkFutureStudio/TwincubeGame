using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public static CountDownTimer instanvce;
    float currentTime = 0f;
    float startTime = 60f;
    [SerializeField] Text countdownText;
    private void Start()
    {
        currentTime = startTime;
    }
    void Update()
    {
        currentTime -= Time.deltaTime;
        print(currentTime);
        countdownText.text = currentTime.ToString ("00");
        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }

    public void ChangeTime(int Timevalue)
    {
        currentTime += Timevalue;
        countdownText.text = currentTime.ToString();
    }
}
