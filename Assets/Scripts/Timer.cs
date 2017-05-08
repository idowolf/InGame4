﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
    public float timeLeft = 20.0f;
    public Text timerText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        string minSec = (timeLeft > 15.0f) ? string.Format("{0}:{1:00}", (int)timeLeft / 60, (int)timeLeft % 60) :
            ((timeLeft > 0) ? System.Math.Round(timeLeft, 2).ToString() : "0.00");
        timerText.text = minSec;
        
        if (timeLeft < 0f)
        {
            SceneManager.LoadScene("gameOverScene");
        }
    }

    public void addTimer (float x)
    {
        timeLeft += x;
    }
    
}
