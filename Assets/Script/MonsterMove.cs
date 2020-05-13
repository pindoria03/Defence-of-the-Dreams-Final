using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMove : MonoBehaviour
{
    GameObject mainworldgate;

    NavMeshAgent navmeshagent;

    // Start is called before the first frame update
    void Start()
    {
        navmeshagent = this.GetComponent<NavMeshAgent>();
        mainworldgate = GameObject.FindWithTag("EndGate"); //find main world door

        if (navmeshagent == null)
        {
            Debug.Log("No navmesh!");
        }
        else
        {

            setdestination(); //call function

        }
    }

    private void setdestination()
    {
            Vector3 targetvector = mainworldgate.transform.position; //set  target vector to the main world door postion
            navmeshagent.SetDestination(targetvector); //set the target of the navmesh agent
    }
    
}
