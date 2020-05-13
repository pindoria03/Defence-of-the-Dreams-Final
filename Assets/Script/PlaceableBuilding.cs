using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlaceableBuilding : MonoBehaviour
{
    [HideInInspector]
    public List<Collider> colliders = new List<Collider>();
    private bool isselected;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        if(isselected)
        {
            if(GUI.Button(new Rect(100, 400, 100, 30), "Sell")) //sell button
            {
                sell(); //sell function
                
            }
            
        }
    }

    void OnTriggerEnter(Collider c) //add collided object to list if colliding with tower, walls or trap
    {
        if(c.tag == "Tower" || c.tag == "Trap" || c.tag == "WallH" || c.tag == "WallC")
        {
            colliders.Add(c);
        }
    }

    void OnTriggerExit(Collider c) //remove collided object from list
    {
        if (c.tag == "Tower" || c.tag == "Trap" || c.tag == "WallH" || c.tag == "WallC")
        {
            colliders.Remove(c);
        }
    }

    public void SetSelected(bool s) //
    {
        isselected = s;
    }

    public void sell() //destroy sold gameobject
    {
        Destroy(gameObject);
        Debug.Log("sold");

    }
}
