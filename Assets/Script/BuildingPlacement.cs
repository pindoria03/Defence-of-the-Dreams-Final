using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{
    private PlaceableBuilding placeablebuilding;
    private Transform currentBuilding;
    private bool hasplaced;
    public LayerMask buildingsMask;
    public GameObject Tower;
    public GameObject Trap;
    public GameObject WallV;
    //public GameObject WallH;
    public GameObject Bank;
    int cost;
    float balance;
    public bool balancecheck;



    private PlaceableBuilding placebuildingold;
    
    // Start is called before the first frame update
    void Start()
    {
        Bank = GameObject.Find("Bank"); //find back when the scene loads
    }

    // Update is called once per frame
    void Update()
    {
       
        
        Vector3 m = Input.mousePosition; //position of the mouse
        m = new Vector3(m.x, m.y, transform.position.y); 
        Vector3 p = GetComponent<Camera>().ScreenToWorldPoint(m); //postiom of the camera

        if (currentBuilding != null && !hasplaced) //if the current building is not null and hasn't been placed
        {
            
            currentBuilding.position = new Vector3(p.x, 0, p.z); //get the position of the building

            if(Input.GetMouseButtonDown(0)) //if left click is pressend
            {
                
                if(IsLegalPos()) //check if the position is legal
                { 
                    hasplaced = true; //has been placed
                    
                }
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0)) //if left mouse button is clicked
            {
                RaycastHit hit = new RaycastHit(); //draw a ray cast
                Ray ray = new Ray(new Vector3(p.x, 8, p.z), Vector3.down); 
                if(Physics.Raycast(ray, out hit, Mathf.Infinity,buildingsMask)) 
                {
                    if (placebuildingold != null) //if the object is not null
                    {
                        placebuildingold.SetSelected(false); //set the selctected to false
                    }
                    hit.collider.gameObject.GetComponent<PlaceableBuilding>().SetSelected(true);
                    placebuildingold = hit.collider.gameObject.GetComponent<PlaceableBuilding>();
                }
                else
                {
                    if (placebuildingold != null)
                    {
                        placebuildingold.SetSelected(false);
                    }

                }


            }
        }
    }

    bool IsLegalPos()
    {
        
        if(placeablebuilding.colliders.Count > 0) //check if the building is colliding with placed objects
        {
            return false; //if colliding return false
        }
        return true; //if not colling return true
    }

    public void setItem(GameObject b)
    {
       hasplaced = false;
       currentBuilding = ((GameObject)Instantiate(b)).transform; //set the current building to the instantiated gameobject
       placeablebuilding = currentBuilding.GetComponent<PlaceableBuilding>(); 
    }
}
