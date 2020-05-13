using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpUI : MonoBehaviour
{
    public GameObject HelpCanvas;
    public GameObject Mining;
    public GameObject Defence;
    public GameObject Walking;

    void Start() //deactive all canvas and panels for the help menu
    {
        HelpCanvas.SetActive(false);
        Mining.SetActive(false);
        Defence.SetActive(false);
        Walking.SetActive(false);
    }

    public void loadmining()//2nd help screen
    {
        Walking.SetActive(false); //deactivate previous
        Mining.SetActive(true); //activate current
    }

    public void loaddefense() //3rd help screen
    {
        Mining.SetActive(false); //deactivate previous
        Defence.SetActive(true); //activate current
    }


    public void loadwalking()
    {
        HelpCanvas.SetActive(true); //activate canvas
        Walking.SetActive(true); //activate current

    }

    public void exithelp()
    {
        Defence.SetActive(false);//deactive 
        HelpCanvas.SetActive(false);//deactive 
    }
}
