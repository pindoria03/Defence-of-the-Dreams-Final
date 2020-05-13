using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretE : MonoBehaviour
{
    //the reason these varaiables are public is so i can change them in the inspector and so they can be accessed by other script
    public Transform target; //variable with the data type transform
    public float range = 5f; //range of the turret
    public float turnspeed = 10f; //turn speed of the turret
    public Transform PartToRotate; //the part of the turret that rotates

    public float FireRate = 1f; //fire tate of turret
    public float firecountdown = 0f; //fire rate cooldown

    public GameObject BulletPrefab; //bullet prefab which the turret shoots
    public Transform Firepoint; //point of fire from the turret

    public string EnemyTag = "Enemy"; //enemy tag string called enemy

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); //upgate the target every 0.5 seconds

    }

    void UpdateTarget()//update target function
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag); //i created an array to hold the enemies found within the range with the tag enemytag
        float ShortestTarget = Mathf.Infinity; //created a float variable and made it equal to infinity
        GameObject NearestEnemy = null; //make the nearest enemy game onject to null

        foreach (GameObject enemy in enemies)
        {
            float DistanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); //created a float variable to hold the distance to emy is equal to the distance between the postion of the turret and the position of the enemy
            if (DistanceToEnemy < ShortestTarget)//if the shortest enemy is greater than the distance to the enmy
            {

                ShortestTarget = DistanceToEnemy;//distance to enemy is equal to the shortest target
                NearestEnemy = enemy; //make the enmy equal to the nearest enemy
            }
        }
        if (NearestEnemy != null && ShortestTarget <= range)// if the nearest enemy is not null and the shortest targets is less than or equal to the range
        {

            target = NearestEnemy.transform; //make the target equal to the nearest enemy transform
        }
        else
        {

            target = null; //make target equal null
        }
    }

    void Update()
    {
        if (target == null) //if the target is null
        {
            return;
        }

        Vector3 dir = target.position - transform.position; //created a direction vector which holds the value of the calculation
        Quaternion lookRoation = Quaternion.LookRotation(dir); ;//created a variable used for the rotation
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRoation, Time.deltaTime * turnspeed).eulerAngles; //created a vector variable which rotates the part that rotates to the target
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);// rotate around the y axis only

        if (firecountdown <= 0f)//if the fire rate cool down is less than or equal to 0
        {
            shoot(); //call shoot function
            firecountdown = 1f / FireRate;//firecountdown is calculated by dividing1 by the fire rate 
        }
        firecountdown -= Time.deltaTime; //descrease the cooldown by 1 
    }

    void shoot() //shoot function
    {
        GameObject BulletGameObject = (GameObject)Instantiate(BulletPrefab, Firepoint.position, Firepoint.rotation);// 
        BulletE Bullet = BulletGameObject.GetComponent<BulletE>();

        if (Bullet != null)
        {
            Bullet.Find(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 1);
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
