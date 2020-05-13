using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Orespawn : MonoBehaviour
{
    public GameObject OreA;
    public GameObject OreB;
    public GameObject OreC;
    public int[] ore = new int[10];
    public Transform spawnlocations;

    // Start is called before the first frame update
    void Start()
    {
        spawnore(); //scene load call function
    }

    void pickore()

    {
        System.Random ran = new System.Random();
        for (int i = 0; i < 10; i++)
        {
            
            ore[i] = ran.Next(1, 10); // random number between 1 and 10
        }
        
    }

    void spawnore()
    {
        pickore(); //call function
        for(int i = 0; i <10; i++)
        {
            if (ore[i] == 1|| ore[i] == 2 || ore[i] == 3 || ore[i] == 4 || ore[i] == 5) //1 to 5 ore a
            {
                Instantiate(OreA, spawnlocations.GetChild(i).position, Quaternion.identity);
            }
            else if(ore[i] == 6|| ore[i] == 7 || ore[i] == 8) // 6 to 8 ore b
            {
                Instantiate(OreB, spawnlocations.GetChild(i).position, Quaternion.identity);
            }
            else if(ore[i] == 9 || ore[i] == 10) //9 or 10 ore c
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
