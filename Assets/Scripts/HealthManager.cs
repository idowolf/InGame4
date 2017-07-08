using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
    public Slider healthSlider;
    public float timeFromStart;
	// Use this for initialization
	void Start () {
        healthSlider.value = 100;
        timeFromStart = 0;
	}
	
	// Update is called once per frame
	void Update () {
        healthSlider.value -= (4*Time.deltaTime);
        if (healthSlider.value <= 0)
        {
            healthSlider.value = 0;
            //TODO : --GAME OVER-- 
        }
	}

    public void giveLife(int x)
    {
        healthSlider.value += x;
    }
}
