using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {
    public float movementSpeed = 0.2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * Time.deltaTime * movementSpeed;
	
	}
}
