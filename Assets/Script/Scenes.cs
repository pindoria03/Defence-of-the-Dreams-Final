using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public GameObject Bank;
    public GameObject counter;

    public void loaddreamworld()
    {
        SceneManager.LoadScene(2); //load scene 2
        Bank.GetComponent<Bank>().entereddreaworld = 1; //player had entered dream world
        counter.GetComponent<Counter>().seconds = 0; //set seconds to 0
    }
}

