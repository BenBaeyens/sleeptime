using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using System;
using TMPro;

public class AppManager : MonoBehaviour {
    Animator animator;

    public GameObject wakeupmenu;
    
    public TMP_InputField wakeupTime;
    public string[] temparray;
    public string time;
    int minutes;
    int hours;

    private void Start() {
        animator = GetComponent<Animator>();



    }

    private void Update() {










    }


    public void QuitApp() {
        Application.Quit();
    }

    public void WakeupMenuOpen() {
        animator.SetTrigger("Wakeup2");
        wakeupmenu.transform.SetAsLastSibling();

    }

    public void CalculateTime(int t) {
        string[] temp = DateTime.Now.TimeOfDay.ToString().Split(':');
        hours = int.Parse(temp[0]);
        minutes = int.Parse(temp[1]);

        minutes += 14;
        for (int i = 0; i < t; i++)
        {

            hours += 1;
            minutes += 40;


            if (minutes >= 60)
            {
                minutes -= 60;
                hours += 1;
            }
            if (hours >= 24)
                hours -= 24;
        }

        time = string.Format("{0:00}:{1:00}", hours, minutes);
        Debug.Log(time);
    }

    public void CalculateWakeUpTime(int t) {
        minutes -= 14;
        for (int i = 0; i < t; i++)
        {

            hours -= 1;
            minutes -= 40;


            if (minutes < 0)
            {
                minutes += 60;
                hours -= 1;
            }
            if (hours < 0)
                hours += 24;
        }

        time = string.Format("{0:00}:{1:00}", hours, minutes);

    }

    public void wakeUpFixText() {


        string firstpart = wakeupTime.text.Substring(0, 2);
        string secondpart = wakeupTime.text.Substring(2, 2);
        hours = int.Parse(firstpart);
        minutes = int.Parse(secondpart);
        wakeupTime.text = firstpart + ":" + secondpart;

   
    }
}
