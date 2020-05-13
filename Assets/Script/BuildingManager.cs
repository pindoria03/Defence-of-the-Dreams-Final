using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] buildings;
    private BuildingPlacement buildingplacement;
    public bool buildingmode;
    
    // Start is called before the first frame update
    void Start()
    {
        buildingplacement = GetComponent<BuildingPlacement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI() 
    {
        if(buildingmode == true)
        {
            for (int i = 0; i < buildings.Length; i++)
            {
                if (GUI.Button(new Rect(Screen.width / 20, Screen.height / 15 + Screen.height / 12 * i, 100, 20), buildings[i].name)) //create a button for each building in the array, with it's name
                {
                    buildingplacement.setItem(buildings[i]); //set the item the button represents
                }
            }
        }
        
    }
}
