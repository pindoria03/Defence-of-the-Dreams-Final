using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainWorldDoor : MonoBehaviour
{
    public float corruptionlevel;
    public GameObject TestLayout;
    private int testcounter;
    public GameObject ResetButton;
    public GameObject Playbutton;
    public float waitseconds;
    public float timer;
    public GameObject gamecontroller;
    public int lives;
    //public Text LivesUI;
    public GameObject Bank;
    public bool dead = false;

    void Start()
    {
        Bank = GameObject.Find("Bank"); //find bank gameobject
        corruptionlevel = Bank.GetComponent<Bank>().corruptionlevel;
    }

    void update()
    {
        timer = timer - Time.deltaTime; //timer
        if(lives <= 0) //all lives lost
        {
            gamecontroller.GetComponent<Spawner>().Allspawned = true;
            Bank.GetComponent<Bank>().corruptionlevel = corruptionlevel;
            dead = true;
        }

    }
    void OnTriggerEnter(Collider collision)
    {
       
        if (collision.CompareTag("Enemy")) //collision with enemy
        {
            Destroy(collision.gameObject); //destroy enemy
            corruptionlevel = corruptionlevel + 0.5f; //addd half corruption level
            lives = lives - 1; //lose a life
        }
        if(collision.CompareTag("TestEnemy")) //collision with test enemy
        {
            Destroy(collision.gameObject); //destroy test enemy
            testcounter++; //add 1 to test counter
            
            if (testcounter == 4) //if test counter is 4
            {
                TestLayout.GetComponent<TestLayout>().testsuccess = true; //test successful
               
                Playbutton.SetActive(true); //show play button
                
            }
            
            else if(timer < 0) //if timer is 0
            {
                
                ResetButton.SetActive(true); //show reset button

            }

        }
        
    }
    
    IEnumerator wait()
    {
        yield return new WaitForSeconds(waitseconds);
    }

}
