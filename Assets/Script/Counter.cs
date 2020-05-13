using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Counter : MonoBehaviour
{
    public float seconds;
    public bool dreamworld;
    public float dreamworldtime;
    public float maxday;
    public GameObject EnterDreamWorld;
    public GameObject bank;
    

    // Start is called before the first frame update
    void Start()
    {
        seconds = 0; //set seconds to 0
    }
    // Update is called once per frame
    void Update()
    {
        seconds = seconds + Time.deltaTime; //increase seconds with time
        if(seconds == 0) //if seconds is 0
        {
            weather(); //run weather function
        }
        else if (seconds < dreamworldtime) // if seconds is less than dream time 
        {
            dreamworld = false; //dream world is false
        }
        else if(seconds >= dreamworldtime) //if seconds is greater than or equal to dream time
        {
            dreamworld = true; //dream world is true
            EnterDreamWorld.SetActive(true); //activate the dream world portal
        }
        else if(seconds == maxday) //if seconds get to max day
        {
            seconds = 0; //reset the seconds to 0
            dreamworld = false; //dream world is closed
            EnterDreamWorld.SetActive(false); //deactive the portal
            int i;
            i = bank.GetComponent<Bank>().entereddreaworld; //access variable from the bank
            if(i == 0) //if the varaible is 0
            {
                bank.GetComponent<Bank>().corruptionlevel = bank.GetComponent<Bank>().corruptionlevel + 5; //add 5 corrution to the player total
            }
        }
    }

    public void weather()
    {
        System.Random ran = new System.Random(); //random number gen
        int weather = ran.Next(0, 1); //between 0 and 1
        bank.GetComponent<Bank>().weather = weather; //set the weather to the weather variable inthe bank script
    }
}
