using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpwards : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.y += 0.1f*Time.deltaTime;
        transform.position = pos;
	}
}
