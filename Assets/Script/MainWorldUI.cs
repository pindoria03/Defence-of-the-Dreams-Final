using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainWorldUI : MonoBehaviour
{
    public GameObject Bank;
    public GameObject GameController;
    public Text Weather;
    public Text Corruptionlevel;
    public Text DreamDimension;
    public Text OreA;
    public Text OreB;
    public Text OreC;



    // Update is called once per frame
    void Update()
    {
        updateUI(); //call function
    }

    void updateUI()
    {
        if(Bank.GetComponent<Bank>().weather == 0) //if sunny
        {
            Weather.color = Color.yellow; //text colour yellow
            Weather.text = "Weather: Sunny"; 
        }
        else //raining
        {
            Weather.color = Color.blue; //text colour blue
            Weather.text = "Weather: Raining";
        }

        Corruptionlevel.text = "Corruption Level: " + Bank.GetComponent<Bank>().corruptionlevel.ToString();//corruption level
        if(GameController.GetComponent<Counter>().seconds > GameController.GetComponent<Counter>().dreamworldtime) //if dream dimension is open
        {
            DreamDimension.color = Color.green; //text colour green
            DreamDimension.text = "Dream Dimension Open";
        }
        else //dream dimension closed
        { 
            DreamDimension.color = Color.red; //text colour red
            DreamDimension.text = "Dream Dimension Closed";
        }

        //ore values to string from an int
        OreA.text = "Ore A: " + Bank.GetComponent<Bank>().oreA.ToString();
        OreB.text = "Ore B: " + Bank.GetComponent<Bank>().oreB.ToString();
        OreC.text = "Ore C: " + Bank.GetComponent<Bank>().oreC.ToString();
    }
}
