﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class PlayButton : MonoBehaviour {
    public float gazeTime = 1f;
    private float timer;
    private bool gazedAt;
    public LifeBar lifeBar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gazedAt)
        {
            timer += Time.deltaTime;
            if (timer >= gazeTime)
            {
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                timer = 0f;
                //GetComponent<Collider>.enabled = false;
            }
        }
	}
    public void PointerEnter()
    {
        lifeBar.duration = gazeTime;
        lifeBar.setActivated = true;
        gazedAt = true;
    }
    public void PointerExit()
    {
        lifeBar.deactivate();
        timer = 0;
        gazedAt = false;
    }
    public void PointerDown()
    {
        SceneManager.LoadScene("level2");
    }
    public void PointerDownExit()
    {
        //Application.Quit();
    }
}
