using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int cost;
    public float damage;

    void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Enemy")) //if collidsion with an enemy
        {
            collision.GetComponent<Enemy>().health = collision.GetComponent<Enemy>().health - damage; //damage the enemy
        }


    }

}
