using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleManager : MonoBehaviour {
    public static float currentCircleStartTime;
    public static float prevCircleStartTime;
    public static float rpm;
    public static float timeFromStart;
    private float minute = 60f;
    public int hitCounter;

    public GameObject burner;
    public bool makeItBigger;
    float[] rpmArray = new float[11];
    // Use this for initialization
    void Start () {
        currentCircleStartTime = 0;
        prevCircleStartTime = 0;
        hitCounter = 0;
        makeItBigger = true;
        setRpmArray(35, 2);
	}
	
	// Update is called once per frame
	void Update () {
        timeFromStart += Time.deltaTime;
        if (makeItBigger) burner.transform.localScale *= 1.0018f;
	}

    public void gazeActive()
    {
        prevCircleStartTime = currentCircleStartTime;
        currentCircleStartTime = timeFromStart;
        rpm = minute / (currentCircleStartTime - prevCircleStartTime);
        Debug.Log("rpm is: " + rpm);
        hitCounter++;
        if (hitCounter % 2 == 0)
        {
           if (rpmArray[hitCounter] <= rpm) burner.transform.localScale *= .85f;
        }
    }

    public void setRpmArray(float mid,float diff)
    {
        float first = mid - (5 * diff);
        for (int i = 0; i < 11; i++)
        {
            rpmArray[i] = mid + (diff * i);
        }
    }
}
