using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {
    public float timeLeft = 60.0f;
    public Text timerText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        timerText.text = "Time Left:" + Mathf.Round(timeLeft);
        
        if (timeLeft < 0f)
        {

        }
    }

    public void addTimer (float x)
    {
        timeLeft += x;
    }
    
}
