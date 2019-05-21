using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using System;
using TMPro;

public class AppManager : MonoBehaviour {
    Animator animator;


    string menuIndex;
    public GameObject sleepmenu;
    public GameObject wakeupmenu;
    public GameObject wakeupmenu1submenu;
    
    public TMP_InputField wakeupTime;
   
    public string time;
    int minutes;
    int hours;

    int wakeuphours;
    int wakeupminutes;

    private void Start() {
        animator = GetComponent<Animator>();



    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuIndex == "SleepNow")
            {
                animator.SetTrigger("Sleepclose");
            }
            if (menuIndex == "Wakeup")
                animator.SetTrigger("Wakeupclose");
            
        }

    }


    public void QuitApp() {
        Application.Quit();
    }

    public void WakeupMenuOpen() {
        animator.SetTrigger("Wakeup2");
        wakeupmenu1submenu.SetActive(false);
        wakeupmenu.transform.SetAsLastSibling();
        menuIndex = "Wakeup";

    }

    public void CalculateTime(int t) {
        string[] temp = DateTime.Now.TimeOfDay.ToString().Split(':');
        hours = int.Parse(temp[0]);
        minutes = int.Parse(temp[1]);

        minutes += 14;
        for (int i = 0; i < t; i++)
        {

            hours += 1;
            minutes += 50;

            if(minutes >= 70)
            { minutes -= 70;
                hours++;
            }
            if (minutes >= 60)
            {
                minutes -= 60;
                hours += 1;
            }
            if (hours >= 24)
                hours -= 24;
        }

        time = string.Format("{0:00}:{1:00}", hours, minutes);
       
    }

    /*public void CalculateWakeUpTime(int t) {
        hours = wakeuphours;
        minutes = wakeupminutes;
        Debug.Log(hours + minutes.ToString());

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

    }*/
    // THIS IS LITERALLY THE OPPOSITE, THE "WHEN SHOULD YOU GO TO BED IF YOU WAKE UP AT ... "

    public void CalculateWakeUpTime(int t) {
            hours = wakeuphours;
            minutes = wakeupminutes;
            Debug.Log(hours + minutes.ToString());

            minutes += 14;
            for (int i = 0; i < t; i++)
            {

                hours += 1;
                minutes += 45;

            if (minutes >= 70)
            {
                minutes -= 70;
                hours++;
            }
            if (minutes >=60)
                {
                    minutes -= 60;
                    hours += 1;
                }
                if (hours >= 24)
                    hours -= 24;
            }

            time = string.Format("{0:00}:{1:00}", hours, minutes);

        }

    public void SleepnowOpen() {
        sleepmenu.transform.SetAsLastSibling();
        animator.SetTrigger("Sleepnow");
        menuIndex = "SleepNow";

    }


    public void wakeUpFixText() {


        string firstpart = wakeupTime.text.Substring(0, 2);
        string secondpart = wakeupTime.text.Substring(2, 2);
        wakeuphours = int.Parse(firstpart);
        wakeupminutes = int.Parse(secondpart);
        Debug.Log(wakeuphours + wakeupminutes.ToString());
        wakeupTime.text = firstpart + ":" + secondpart;

   
    }

    public void openKeyboard() {
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.NumberPad, false, false, true, false);
    }
}
