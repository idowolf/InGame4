﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform traget;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void LateUpdate () {
        
        transform.position = traget.position + offset;
    }
}