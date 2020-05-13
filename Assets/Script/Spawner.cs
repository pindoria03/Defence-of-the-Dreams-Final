using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    public Text timebetweenwaves;
    public enum SpawnState { SPAWNING, WAITING, COUNTING }; // created 3 states the game will be in during spawning
    public Transform enemy; //store the lv1 level
    public Transform enemy2; //store the lv2 enemy
    public Transform enemy3; //store the lv3 enemy
    public Transform enemy4; //store the lv4 enemy
    public Transform wenemy; //store the lv1 level
    public Transform wenemy2; //store the lv2 enemy
    public Transform wenemy3; //store the lv3 enemy
    public Transform wenemy4; //store the lv4 enemy
    public int weather;
    public bool Allspawned;
    public GameObject inbuidlingmode;
    public bool buildingmodebool = true;
    public GameObject Bank;


    [System.Serializable]
    public class Wave //create a class for each wave
    {

        // [Space()] add space between fields in the inspector
        public string name; //wave name
        [Space(20)]
        public int count; //count of lv1 monsters
        public float rate = 1; //spawn rate of lv1 monsters
        [Space(10)]

        public int count2; //count of lv2 monsters
        public float rate2 = 1; //spawn rate of lv2 monsters
        [Space(10)]

        public int count3;//count of lv3 monsters
        public float rate3 = 1; //spawn rate of lv3 monsters
        [Space(10)]

        public int count4;//count of lv4 monsters
        public float rate4 = 1; //spawn rate of lv4 monsters
        
    }

    


    public Wave[] waves; //create an array of waves
    public float nextWave = 0; //set the wave number to 0
    public int NextWave //add 1 to wave number and return it
    {
        get { return (int)nextWave + 1; }
    }

    public Transform[] spawnPoints; //create an array of spawners

    public float timeBetweenWaves = 5f; //set the time between waves time
    public float waveCountdown = 5 ; //wave countdown 
    public float WaveCountdown
    {
        get { return waveCountdown; }
    }

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING; //if the game state is in counting
    public SpawnState State //return the game state
    {
        get { return state; }
    }

    
    void Start() //set the wave countdown to the time between waves
    {
        waveCountdown = timeBetweenWaves; //set the wave countdown to the time between waves
        Bank = GameObject.Find("Bank");
        weather = Bank.GetComponent<Bank>().weather;

        if (spawnPoints.Length == 0) //if there are 0 waypoints
        {
            // Debug.LogError("No spawn points referenced.");
        }
                
        if(inbuidlingmode.GetComponent<BuildingManager>().buildingmode == true)
        {
            buildingmodebool = true; //in building mode
        }
        else
        {
            buildingmodebool = false; //not in buidling mode
        }


    }

    void Update()
    {
        timebetweenwaves.text = "Next Wave In: " + Mathf.Floor(waveCountdown).ToString(); //convert the wave countdown to a string
        if (waveCountdown < 0)// if wave countdown is less than 0
        {
            timebetweenwaves.text = "Next Wave In:";
        }
        if (state == SpawnState.WAITING) //if the game state is in waiting
        {
            if (!EnemyIsAlive()) //if there are no enemies alive
            {
                WaveCompleted(); //run the wave complete function
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0 && buildingmodebool == false && Allspawned == false) //if less than or equal to 0
        {
                if (state != SpawnState.SPAWNING && weather == 0 ) //and the game state isn't spawning
            {
                StartCoroutine(SpawnWave(waves[(int)nextWave])); //start spawning the next wave
            }
            else if(state != SpawnState.SPAWNING && weather ==1)
            {
                StartCoroutine(SpawnWaveWater(waves[(int)nextWave]));
            }

        }
        else
        {
            waveCountdown -= Time.deltaTime; //decrease the timer by 1
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");

        state = SpawnState.COUNTING; //game state counting
        waveCountdown = timeBetweenWaves; //set the wave countdown to time between waves

        if (nextWave + 1 > waves.Length - 1) //check if all the waves have spawned
        {
            Allspawned = true;
            //Debug.Log("ALL WAVES COMPLETE! Looping...");
        }
        else
        {
            nextWave++; //add 1 to the wave numebr
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime; //deacrese search countdown 1 second
        if (searchCountdown <= 0f) //if search coundown is less than 0
        {
            searchCountdown = 1f; //set search counter back to 1
            if (GameObject.FindGameObjectWithTag("Enemy") == null) //if there are no enemies
            {
                return false; //return false
            }
        }
        return true; //if there are enemies return true
    }

    IEnumerator SpawnWaveWater(Wave _wave) //spawn wave 
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;//game state spwaning

        for (int i = 0; i < _wave.count; i++) //run a number of times equal to the amount of lv1 monsters in that wave
        {
            SpawnEnemy(wenemy); //the lv1 enemy
            yield return new WaitForSeconds(1f / _wave.rate); //spawn enemy depending on the rate
        }

        for (int i = 0; i < _wave.count2; i++) //run a number of times equal to the amount of lv2 monsters in that wave
        {
            SpawnEnemy(wenemy2); //the lv2 enemy
            yield return new WaitForSeconds(1f / _wave.rate); //spawn enemy depending on the rate
        }
        for (int i = 0; i < _wave.count3; i++)//run a number of times equal to the amount of lv3 monsters in that wave
        {
            SpawnEnemy(wenemy3); //the lv3 enemy
            yield return new WaitForSeconds(1f / _wave.rate); //spawn enemy depending on the rate
        }
        for (int i = 0; i < _wave.count4; i++)//run a number of times equal to the amount of lv4 monsters in that wave
        {
            SpawnEnemy(wenemy4); //the lv4 enemy
            yield return new WaitForSeconds(1f / _wave.rate); //spawn enemy depending on the rate
        }
     
        state = SpawnState.WAITING; // change game state to wait

        yield break; //break out the code block
    }

    IEnumerator SpawnWave(Wave _wave) //spawn wave 
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;//game state spwaning

        for (int i = 0; i < _wave.count; i++) //run a number of times equal to the amount of lv1 monsters in that wave
        {
            SpawnEnemy(enemy); //the lv1 enemy
            yield return new WaitForSeconds(1f / _wave.rate); //spawn enemy depending on the rate
        }

        for (int i = 0; i < _wave.count2; i++) //run a number of times equal to the amount of lv2 monsters in that wave
        {
            SpawnEnemy(enemy2); //the lv2 enemy
            yield return new WaitForSeconds(1f / _wave.rate); //spawn enemy depending on the rate
        }
        for (int i = 0; i < _wave.count3; i++)//run a number of times equal to the amount of lv3 monsters in that wave
        {
            SpawnEnemy(enemy3); //the lv3 enemy
            yield return new WaitForSeconds(1f / _wave.rate); //spawn enemy depending on the rate
        }
        for (int i = 0; i < _wave.count4; i++)//run a number of times equal to the amount of lv4 monsters in that wave
        {
            SpawnEnemy(enemy4); //the lv4 enemy
            yield return new WaitForSeconds(1f / _wave.rate); //spawn enemy depending on the rate
        }
        

        state = SpawnState.WAITING; // change game state to wait

        yield break; //break out the code block
    }

    void SpawnEnemy(Transform _enemy) //spawn an enemy
    {
        //Debug.Log("Spawning Enemy: " + _enemy.name);

        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)]; //at the spawn point
        Instantiate(_enemy, _sp.position, _sp.rotation); // create lv1 enemy at that position
    }
    void SpawnEnemy2(Transform _enemy2)
    {
        //Debug.Log("Spawning Enemy: " + _enemy2.name);

        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy2, _sp.position, _sp.rotation); // create lv2 enemy at that position
    }
    void SpawnEnemy3(Transform _enemy3)
    {
        //Debug.Log("Spawning Enemy: " + _enemy2.name);

        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy3, _sp.position, _sp.rotation); // create lv3 enemy at that position
    }
    void SpawnEnemy4(Transform _enemy4)
    {
        //Debug.Log("Spawning Enemy: " + _enemy2.name);

        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy4, _sp.position, _sp.rotation); // create lv4 enemy at that position
    }
}


