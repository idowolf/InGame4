using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : MonoBehaviour {


    // center of the circle for rotation
    public float xCenter;
    public float yCenter;
    public float zCenter;

    //radius for the circle
    public float radius;

    // angle to use for rotation
    private float angleH;
    private float angleV;

    // timer to increment to initiate rotation
    private float degH;
    private float degV;

    // game object to rotate around
    public Transform target;

    


    // Use this for initialization
    void Start()
    {
        // center of the circle will be at the center of the screen
        xCenter = target.position.x;// Screen.width / 2;
        yCenter = target.position.y;// Screen.height / 2;
        zCenter = target.position.z;
        radius = 10;
        degH = Mathf.PI;
        degV = 1.5f;
        angleH = degH;
        angleV = degV;
        transform.position = new Vector3((xCenter + Mathf.Sin(angleH) * radius), ((yCenter /*+ offset.y*/) - Mathf.Cos(angleV) * radius), (zCenter + Mathf.Cos(angleH) * radius));

    }

    // Update is called once per frame
    void Update()
    {
        
            degH += .03f;
        
        
            //degH -= .03f;
        
        
            degV += .03f;
            degV = Mathf.Clamp(degV, 1.0f, 3.0f); // don't allow the player to go above this because it will start to rotat back down
        
        
        
            //degV -= .03f;
            //degV = Mathf.Clamp(degV, 1.0f, 3.0f); //make sure the camera cant go below the floor
        
        // always make sure the center is at the targets position
        xCenter = target.position.x;
        yCenter = target.position.y;
        zCenter = target.position.z;
        //if (angleH != degH || angleV != degV)
        //{
            angleH = degH;
            angleV = degV;
            Debug.Log("degV = " + degV);
            transform.position = new Vector3((xCenter + Mathf.Sin(angleH) * radius), (yCenter - Mathf.Cos(angleV) * radius), (zCenter + Mathf.Cos(angleH) * radius));
        //}
    }
}
