using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestLayout : MonoBehaviour
{
    public NavMeshSurface surface;
    public GameObject Camera;
    public GameObject gamecontroller;
    public GameObject[] enemytest = new GameObject[4];
    public GameObject Spawner;
    public GameObject TestMode;
    public GameObject PlayLevel;
    public GameObject Mainworld;
    public bool testsuccess = false;
    public bool play;
    public GameObject Bank;
    public GameObject MainworldDoor;


   

    void Start()
    {
        Bank = GameObject.Find("Bank"); //find bank gameobject
    }

    void Update()
    {
        if (gamecontroller.GetComponent<Cost>().checkcomplete == true) //if check is complete
        {
            cost(); //run cost function
        }

        if(gamecontroller.GetComponent<Spawner>().Allspawned == true || MainworldDoor.GetComponent<MainWorldDoor>().dead == true)// if player is dead or all waves spawned
        {
            Mainworld.SetActive(true); //activate mian world door
        }
    }

   public void cost()
    {
        
            TestMode.SetActive(true); //test mode active
        
    }

   
    public void testmode()
    {
        surface.BuildNavMesh(); //build navmesh
        Camera.GetComponent<BuildingManager>().buildingmode = false; //turn off build mode
        StartCoroutine(spawntest()); //start test wave
        TestMode.SetActive(false); //deactivate test button
       
    }

    public void playmode() 
    {
        if(testsuccess == true) //if test succesful
        {
            gamecontroller.GetComponent<Cost>().buy();//fun buy function
            play = false;
            gamecontroller.GetComponent<Spawner>().buildingmodebool = play; //disable build mode to allow spawning
            PlayLevel.SetActive(false); //disable play button
        }
    }

    public void restartmode() 
    {
        if(testsuccess == false) //if test failed
        {
            Camera.GetComponent<BuildingManager>().buildingmode = true; //activate build mode
            TestMode.SetActive(true); //enable test button
        }
    }


    IEnumerator spawntest() //spawn test wave
    {

        for (int i = 0; i < 4; i++)
        {
            Instantiate(enemytest[i], Spawner.transform.position, Spawner.transform.rotation);
            yield return new WaitForSeconds(1);
        }       
    }
    
    public void mainworld() //load main world
    {
        SceneManager.LoadScene(0);
        Bank.GetComponent<Bank>().entereddreaworld = 0; //reset the value
        Bank.GetComponent<Bank>().corruptionlevel =  MainworldDoor.GetComponent<MainWorldDoor>().corruptionlevel; //transfer the corruption level to the bank
    
    }
}
