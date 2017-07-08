using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newrotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {
        transform.Translate(new Vector3(0, 0, Time.deltaTime * 0.1f)); // move forward
        transform.Rotate(new Vector3(0, Time.deltaTime * 0.1f, 0)); // turn a little

    }

}
