using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreSpawnB : MonoBehaviour
{
    public GameObject OreA;
    public GameObject OreB;
    public GameObject OreC;
    public int[] ore = new int[10];
    public Transform spawnlocations;

    // Start is called before the first frame update
    void Start()
    {
        spawnore(); //call function on start
    }

    void pickore()
    {
        System.Random ran = new System.Random();
        for (int i = 0; i < 10; i++)
        {

            ore[i] = ran.Next(1, 10); //random number between 1 and 10
        }

    }

    void spawnore()
    {
        pickore();
        for (int i = 0; i < 10; i++)
        {
            if (ore[i] == 1 || ore[i] == 2) //1 or 2 ore a
            {
                Instantiate(OreA, spawnlocations.GetChild(i).position, Quaternion.identity);
            }
            else if (ore[i] == 3 || ore[i] == 4 || ore[i] == 5 || ore[i] == 6 || ore[i] == 7 ) //3 to 7 ore b
            {
                Instantiate(OreB, spawnlocations.GetChild(i).position, Quaternion.identity);
            }
            else if (ore[i] == 8 || ore[i] == 9 || ore[i] == 10) //8 to 10 ore c
            {
                Instantiate(OreC, spawnlocations.GetChild(i).position, Quaternion.identity);
            }
        }
    }

    

    IEnumerator seconds()
    {
        System.Random ran2 = new System.Random();
        float seconds = ran2.Next(10, 30);
        yield return new WaitForSeconds(seconds);
    }
}
