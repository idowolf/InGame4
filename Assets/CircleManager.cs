using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleManager : MonoBehaviour {
    public static float currentCircleStartTime;
    public static float prevCircleStartTime;
    public static float rps;
    public static float timeFromStart;
    public static float energyMass;
    public static int hitCounter;
    public static int score;
    private float scaleFactor;
    private Vector3 scaleFactorV;


    public GameObject burner;
    
    // Use this for initialization
    void Start () {
        currentCircleStartTime = 0;
        timeFromStart = 0; 
        prevCircleStartTime = 0;
        hitCounter = 0;
        scaleFactor = (1f / 15f);
        energyMass = 0;
        score = 0;
        
    }
	
	// Update is called once per frame
	void Update () {
        timeFromStart += Time.deltaTime;
        //if player hasnt finish a full spin- therefore want to shoot his energy ball
        score = (int)energyMass * 1000;

        //player stopped spinning
        if (timeFromStart - currentCircleStartTime > 3f) {

            //TODO: decide what score is enough to impact
            //TODO: complite scene names options
            string sceneName = (score > 4500) ? "gameOverScene" : "gameOverScene";
            SceneManager.LoadScene(sceneName);
        }
        


    }

    public void gazeActive()
    {
        prevCircleStartTime = currentCircleStartTime;
        currentCircleStartTime = timeFromStart;
        rps = 1 / (currentCircleStartTime - prevCircleStartTime);

        hitCounter++;
        //if number of hits is ZUGI then a spin has ended
        if (hitCounter % 2 == 0)
        {

            if (rps > .5) {
                //Debug.Log("rps is: " + rps);
                float temp = rps * scaleFactor;
                scaleFactorV = new Vector3(temp, temp, temp);
                burner.transform.localScale += scaleFactorV;
                energyMass += rps;
            }
        }
        
    }

   
}
