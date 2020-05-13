using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageData : MonoBehaviour
{
    public GameObject Bank; //bank gameobject

    private void Awake()
    {
        ManageData instance = FindObjectOfType<ManageData>();

        if (instance.GetComponent<ManageData>() != this)
        {
            Destroy(Bank); //acoid having more than one bank gameobject
        }
        else
        {
            DontDestroyOnLoad(this.Bank); //don't destroy on load
        }
    }
}
