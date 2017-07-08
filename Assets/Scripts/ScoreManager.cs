using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour {
      
    public static int score;
    int shotFired;
    public float timeFromStart;
    int numberOfRotations;
    public ChooseQuarter chooseQuarter;
    public SphereController sphereControler;
    // Use this for initialization
    void Start () {
        score = 0;
        timeFromStart = 0;
        
    }

    // Update is called once per frame
    void Update () {
        timeFromStart += Time.deltaTime;
        
    }

    public void gameOver()
    {
        numberOfRotations = chooseQuarter.quartersCount / 4;
        score += numberOfRotations;
        shotFired = sphereControler.shotsCount;
        score += shotFired;
        score += (int)timeFromStart;
        SceneManager.LoadScene("gameOverScene");
    }
    
}
