using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colideme : MonoBehaviour {
    public ScoreManager scoreManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Renderer>().material.color == Color.red){scoreManager.lives--; }
    }
}
