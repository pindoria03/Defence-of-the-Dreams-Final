using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletN : MonoBehaviour
{
    private Transform target; //crated a variable holding the transformation information of the target
    public float speed = 70f; //created a variable for the speed of the bullet
    public float damage;

    public void Find(Transform Target) //a function that takes in a parameter
    {
        target = Target; //make the target equal to the parameter
    }

    void Update() //update function
    {
        if (target == null) //check if the target it null
        {
            Destroy(gameObject); //destroy the bullet game object
            return;
        }

        Vector3 dir = target.position - transform.position; //direction vector is calculated by get the target postion and taking away the transform position
        float distanceThisFrame = speed * Time.deltaTime; // calculate the speed of the bullet for the frames per second

        if (dir.magnitude <= distanceThisFrame) //if the directions magniture is less than or equal to the to the direction this frame
        {
            HitTarget(); //call the hit target function
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World); //moves the bullet. The direction is normalized to keep the direction of the vector but makes the length of the vector to 1.
                                                                              //multiply the direction by the bullet speed per frame, in terms of the world space not the local space                                                                  
    }

    void HitTarget() //hit target function
    {
        Damage(target);
        Destroy(gameObject);

    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if(e != null)
        {
            e.TakeDamage(damage);
        }
        
    }
}
