using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WakeupTimeDisplayer : MonoBehaviour {
    public int cycleNumbers;

    AppManager appManager;
    TextMeshProUGUI text;

    private void Awake() {
        appManager = GameObject.Find("Main").GetComponent<AppManager>();
        text = GetComponent<TextMeshProUGUI>();
        appManager.CalculateWakeUpTime(cycleNumbers);
        text.text = appManager.time;
    }
}
