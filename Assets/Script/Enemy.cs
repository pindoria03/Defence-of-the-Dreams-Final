using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

        public float speed; //enemy speed

        public float health; //enemy health

        public string type;

       

        public void TakeDamage(float amount) //function taking in a damage number
        {
            health -= amount; //take the damage away from the health of the enemy

            if (health <= 0) //if the death is less than or equal to 0
            {
                Die(); //call die function
            }
        }
      
        void Die() // die function
        {
            Destroy(gameObject);
            

        }

    
}
