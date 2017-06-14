using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour {
    public float lerpingTime = 0f;
    public bool setActivated;
    public bool active;
    public float duration = 3f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (setActivated)
        {
            lerpingTime = 0f;
            active = true;
            setActivated = false;
        }
        if (active)
        {
            lerpingTime += Time.deltaTime / duration;
            GetComponent<Renderer>().material.SetFloat("_Cutoff", Mathf.Lerp(1, 0, lerpingTime));
            if (lerpingTime > 1)
            {
                GetComponent<Renderer>().material.SetFloat("_Cutoff", 1);
                active = false;
            }
        }
    }

    public void deactivate()
    {
        GetComponent<Renderer>().material.SetFloat("_Cutoff", 1);
        active = false;
    }
}
