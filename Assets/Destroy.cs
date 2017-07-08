using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
    public float time = 5;
    // Use this for initialization
    void Start () {
    }
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, time);
    }
}
