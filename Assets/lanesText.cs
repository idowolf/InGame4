using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanesText : MonoBehaviour {
    private float elapsedTime;
    public float timeForMessage = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > timeForMessage)
        {
            elapsedTime = 0;
            gameObject.SetActive(false);
        }
	}
    private void OnEnable()
    {
        elapsedTime = 0;
    }
}
