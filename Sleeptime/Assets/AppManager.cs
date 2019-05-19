using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using System;

public class AppManager : MonoBehaviour {
    Animator animator;

  
   
    public string time;
    int minutes;
    int hours;

    private void Start() {
        animator = GetComponent<Animator>();
        
        

        CalculateTime(1);
        CalculateTime(2);
        CalculateTime(3);
            }

    private void Update() {
      



  
       



       
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
          

        if(minutes >= 60)
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

}
