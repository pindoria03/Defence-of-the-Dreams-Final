using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform CamPivot;
    
    public Transform Camera;
    float headingx = 0;
    float headingy = 0;

    public float speed = 5f;
    public float mouseSens = 180f;
    Vector2 input;

    // Update is called once per frame
    void Update()
    {
        headingx += Input.GetAxis("Mouse X") * Time.deltaTime * mouseSens; //x value
        headingy += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSens; //y value
        CamPivot.rotation = Quaternion.Euler(-headingy, headingx, 0);

        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); //vecto of where the player is looking
        input = Vector2.ClampMagnitude(input, 1);

        Vector3 CamF = Camera.forward;
        Vector3 CamR = Camera.right;

        CamF.y = 0;
        CamR.y = 0;
        CamF = CamF.normalized;
        CamR = CamR.normalized;

        transform.position += (CamF * input.y + CamR * input.x) * Time.deltaTime * speed; //move the way you are looking at a certain speed per second
    }
}
