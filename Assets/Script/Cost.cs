using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cost : MonoBehaviour
{
    public int towers;
    public int traps;
    public int wallH;
    public int wallV;

    public int towersC;
    public int trapsC;
    public int wallC;

    public GameObject Bank;
    public Text TowersC;
    public Text TrapC;
    public Text WallC;

    public GameObject[] Buildings = new GameObject[4];

    public float OreATotal;
    public float OreBTotal;
    public float OreCTotal;

    public int checks;
    public bool checkcomplete = false;


    // Start is called before the first frame update
    void Start()
    {
        //find the bank and set the ore totals for this object to the ones of the bank
        Bank = GameObject.Find("Bank");
        OreATotal = Bank.GetComponent<Bank>().oreA;
        OreBTotal = Bank.GetComponent<Bank>().oreB;
        OreCTotal = Bank.GetComponent<Bank>().oreC;

       
    }

    // Update is called once per frame
    void Update()
    {
        costcheckcomplete();        //run function 
    }

    public void FindObjects()
    {
        //find the amount of objects of each type
        towers = GameObject.FindGameObjectsWithTag("Tower").Length;
        traps = GameObject.FindGameObjectsWithTag("Trap").Length;
        wallH = GameObject.FindGameObjectsWithTag("WallH").Length;
        wallV = GameObject.FindGameObjectsWithTag("WallV").Length;
    }
    public void Calculatecost()
    {
        FindObjects(); //run function
        //calculate the costs for each defence
        towersC = towers * Buildings[0].GetComponent<Tower>().cost;
        trapsC = traps * Buildings[1].GetComponent<Trap>().cost;
        wallC = (wallH * Buildings[2].GetComponent<Wall>().cost) + (wallV * Buildings[3].GetComponent<Wall>().cost);
    }

    public void CheckCost()
    {
        Calculatecost(); //run function
        if(OreATotal > towersC) //check if player has enough bala
        {
            //TowersC.color = Color.green;
            checks++; //add 1 to check
        }
        else
        {
            //TowersC.color = Color.red;
            //TowersC.fontStyle = FontStyle.Bold;
        }

        if(OreBTotal > trapsC)
        {
            //TrapC.color = Color.green;
            checks++;
        }
        else
        {
            //TrapC.color = Color.red;
            //TrapC.fontStyle = FontStyle.Bold;
        }

        if(OreCTotal > wallC)
        {
            //WallC.color = Color.green;
            checks++;
        }
        else
        {
            //WallC.color = Color.red;
            //WallC.fontStyle = FontStyle.Bold;
        }
    }

    public void costcheckcomplete()
    {
        CheckCost();
        if(checks == 3) //if check is 3
        {
            checkcomplete = true; //set bool to true
            Debug.Log("check done");
        }
        else
        {
            checkcomplete = false; //if not 3 set bool to false
        }
    }

   public void buy() //take the costs away from the resouces and update the new bank totals.
    {
        OreATotal = OreATotal - towersC;
        OreBTotal = OreBTotal - trapsC;
        OreCTotal = OreCTotal - wallC;
        Bank.GetComponent<Bank>().oreA = OreATotal;
        Bank.GetComponent<Bank>().oreB = OreBTotal;
        Bank.GetComponent<Bank>().oreC = OreCTotal;
    }

}
