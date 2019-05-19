using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeDisplayer : MonoBehaviour {
    public int cycleNumbers;

    AppManager appManager;
    TextMeshProUGUI text;

    private void Start() {
        appManager = GameObject.Find("Main").GetComponent<AppManager>();
        text = GetComponent<TextMeshProUGUI>();
        appManager.CalculateTime(cycleNumbers);
        text.text = appManager.time;
    }
}
