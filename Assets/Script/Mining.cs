using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : MonoBehaviour
{
    public int timetomine;
    public float health;
    public int maxminingdistance;
    public GameObject bank;
   


    private GameObject Player;
    public float counter;
   
    public float corruptionlevel;

    public int levelonedamage;
    public int leveltwodamage;
    public bool level1 = true;
    public bool level2 = false;
    public float currentdamage;
    public float calculatedamage;

    void Update()
    {
        if (level1 == true && level2 == false)
        {
            currentdamage = levelonedamage; //level 1 damage
        }
        else if (level1 == true && level2 == true)
        {
            currentdamage = leveltwodamage; //level 2 damage
        }
    }
    void Start()
    {
        Player = GameObject.Find("Player"); //find player
        bank = GameObject.FindGameObjectWithTag("Bank"); //find bank
        corruptionlevel = bank.GetComponent<Bank>().corruptionlevel; //get corruption level
    }
    
    void OnMouseEnter()
    {
        Vector2 distance = Player.transform.position - transform.position; //find distance of player
        
        if(Input.GetMouseButton(0) && distance.magnitude < maxminingdistance) //if close enough and left clicking
        {
            Debug.Log("Mined"); 
            counter += Time.deltaTime;

            if(counter >= timetomine) //add delay to mining
            {
                Debug.Log("Mined2");


                health = health - currentdamage;
                counter = 0;
            }

            if (health <= 0) //ore mined
            {
                Debug.Log("0 health");
                if(gameObject.name == "Ore A(Clone)") //setting ore health and ore quantity when mined
                {
                    Debug.Log("A");
                    gameObject.GetComponent<Mining>().health = 10;
                    float total = 5 + ((corruptionlevel/100)*5) ;
                    bank.GetComponent<Bank>().oreA = bank.GetComponent<Bank>().oreA + total;
                }
                if (gameObject.name == "Ore B(Clone)")
                {
                    gameObject.GetComponent<Mining>().health = 150;
                    float total = 7 + ((corruptionlevel / 100) * 5);
                    bank.GetComponent<Bank>().oreB = bank.GetComponent<Bank>().oreB + total;
                }
                if (gameObject.name == "Ore C(Clone)")
                {
                    gameObject.GetComponent<Mining>().health = 150;
                    float total = 9 + ((corruptionlevel / 100) * 5);
                    bank.GetComponent<Bank>().oreC = bank.GetComponent<Bank>().oreC + total;
                }

            }

        }
    }
}
