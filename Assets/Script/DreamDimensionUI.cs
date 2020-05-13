using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DreamDimensionUI : MonoBehaviour
{
    public GameObject Bank;
    public GameObject GameController;
    public GameObject MainWorldDoor;

    public Text WaveNumber;
    public Text Corruptionlevel;
    public Text Lives;
    public Text OreA;
    public Text OreB;
    public Text OreC;
    public Text TimebetweenWaves;

    void Start()
    {
        Bank = GameObject.Find("Bank"); //find bank gameobject
    }


    void Update()
    {
        updateUI(); //run update ui function
    }

    void updateUI()
    {
        WaveNumber.text = "Wave: " + GameController.GetComponent<Spawner>().nextWave.ToString(); //wave number text
        Corruptionlevel.text = "Corruption Level: " + MainWorldDoor.GetComponent<MainWorldDoor>().corruptionlevel.ToString(); //corrution level text
        Lives.text = "Lives: " + MainWorldDoor.GetComponent<MainWorldDoor>().lives.ToString(); // lives text
        //ore total text
        OreA.text = "Ore A: " + Bank.GetComponent<Bank>().oreA.ToString();
        OreB.text = "Ore B: " + Bank.GetComponent<Bank>().oreB.ToString();
        OreC.text = "Ore C: " + Bank.GetComponent<Bank>().oreC.ToString();
    }
}
