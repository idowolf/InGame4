﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * THIS CLASS IS NOW CHANGING THE ENEMY SPEED, WE NEED 
 * WE HAVE TO CHANGE ITS NAME ASAP
 * ASAP!!!!
 * A-S-A-P-!-!-!
 * */
 
public class SizeController : MonoBehaviour {

    public float unGazedTime, gazedTime;
    private Vector3 sizeVector;
    public bool isTouched;
    public GameObject ExplosionPrefab;
    private float scalseAtStart ;
    private float scaleFactor;
    public float speedMultiplier = 0.005f;
    // Use this for initialization
    void Start()
    {
        scalseAtStart = transform.localScale.x;
        unGazedTime = 0;
        gazedTime = 0;

    }
	
	// Update is called once per frame
	void Update () {
        
        if (isTouched)
        {
            gazedTime += Time.deltaTime;
            unGazedTime = 0;
            GetComponent<EnemyPath>().speed += speedMultiplier;
            
        }else
        {
            unGazedTime += Time.deltaTime;
            gazedTime = 0;
            if (GetComponent<EnemyPath>().speed <= 0) { GetComponent<EnemyPath>().speed = 0; }
            else
            {
                GetComponent<EnemyPath>().speed -= 0.05f;
            }
        }
        //setScale();
	}

    void setScale()
    {
        //scaleFactor = 1 + (twoSecondsTimer / 2);
        //transform.localScale = scalseAtStart * new Vector3(scaleFactor,scaleFactor,scaleFactor);
        //GetComponent<EnemyPath>().speed += scaleFactor/100;
    }
    
}
