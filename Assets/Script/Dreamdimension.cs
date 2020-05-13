using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dreamdimension : MonoBehaviour
{
    public GameObject counter;
    public GameObject Bank;
    public bool dream;


    void Update()
    {
        if(counter.GetComponent<Counter>().dreamworld == true)
        {
            dream = true;
        }
        else
        {
            dream = false;
        }
    }

    void OnTriggerEnter(Collider Collision)
    {
        if(Collision.CompareTag("Player") && dream == true) //if the collision is the player and the dream world is open
        {
            loaddreamworld(); //load dream world
        }
    }

    public void loaddreamworld()
    {
        SceneManager.LoadScene(2); //load scene 2
        Bank.GetComponent<Bank>().entereddreaworld = 1; 
        counter.GetComponent<Counter>().seconds = 0; //set counter to 0;


    }
}
