using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int cost;

    void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Bullet")) //if collision is with a bullet
        {
            Destroy(collision.gameObject); //destroy the bullet gameobject
        }
    }
}
