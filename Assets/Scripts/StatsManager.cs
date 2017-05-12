using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StatsManager : MonoBehaviour {
    public float timeFromStart , lastRotationTime;
    public int cameraYPosAtStart, cameraYpos;
    public float maxRotationTime, tempRotationTime;
    bool rotationFinished ;

    public float speed, maxSpeed;
    Vector3 lastPosition;

    public int maxCombo;
	// Use this for initialization
	void Start () {
        maxRotationTime = float.MaxValue;
        timeFromStart = 0f;
        lastRotationTime = 0f;
        cameraYPosAtStart =(int) ((transform.parent.GetComponent<Transform>().rotation.y + 180) % 360);
        rotationFinished = false;
        
        lastPosition = GetComponent<Transform>().position;
	}
	
	// Update is called once per frame
	void Update () {
        timeFromStart += Time.deltaTime;
        
        
        calcRotationTime();
        updateMaxCombo();
        updateMaxSpeed();
        lastPosition = GetComponent<Transform>().position;
        maxSpeed = 0f;

    }
    
    
    private void calcRotationTime() {
        cameraYpos =(int) ((transform.parent.GetComponent<Transform>().rotation.y + 180) % 360);
         
        if ((cameraYPosAtStart == cameraYpos))
        {
            if (rotationFinished)
            {
                tempRotationTime = timeFromStart - lastRotationTime;
                lastRotationTime = timeFromStart;
                Debug.Log("last rotation" + tempRotationTime);
                if (tempRotationTime < maxRotationTime)
                {
                    maxRotationTime = tempRotationTime;
                    Debug.Log("max rotation" + maxRotationTime);
                }
                rotationFinished = false;
            }
            
        } else
        {
            rotationFinished = true;
        }
    }

    private void updateMaxCombo()
    {
        maxCombo = maxCombo < ComboManager.ComboLength ? ComboManager.ComboLength : maxCombo;
    }

    private void updateMaxSpeed()
    {
        speed = (GetComponent<Transform>().position - lastPosition).magnitude / Time.deltaTime;
        if (speed > maxSpeed)
        {
            maxSpeed = speed;
            //Debug.Log("s[eed: " + speed);
        }
    }
}
