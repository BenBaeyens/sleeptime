using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeDisplayer : MonoBehaviour
{
    public int cycleNumbers;

    AppManager appManager;
    TextMeshProUGUI text;


    private void Start()
    {

        // Not the most performant, but easy fix

        appManager = GameObject.Find("Main").GetComponent<AppManager>();
        text = GetComponent<TextMeshProUGUI>();
        InvokeRepeating("CalculateTime", 0, 60);
    }

    private void CalculateTime()
    {
        appManager.CalculateTime(cycleNumbers);
        text.text = appManager.time;
    }
}
