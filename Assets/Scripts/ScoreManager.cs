using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ScoreManager : MonoBehaviour {
      
    public static int score;
    int shotFired;
    public float timeFromStart;
    int numberOfRotations;
    public ChooseQuarter chooseQuarter;
    public SphereController sphereControler;
    public GameObject explosion;
    public Transform ufo;
    private bool myflg, activated;
    public AudioSource win;
    public AudioSource lose;
    public static ArrayList scoreArray = new ArrayList();
    public Text first, second, third, yours;
    
    // Use this for initialization
    void Start () {
        Scene currentScene = SceneManager.GetActiveScene();
        timeFromStart = 0;
        if (currentScene.name != "gameOverScene")
        {
            score = 0;
            timeFromStart = 0;
            scoreArray.Add(0);
            scoreArray.Add(0);
            scoreArray.Add(0);
        }
        if (SceneManager.GetActiveScene().name == "gameOverScene" && !activated)
        {
            activated = true;
            if ((scoreArray[0].ToString() == score.ToString()
|| scoreArray[1].ToString() == score.ToString() ||
scoreArray[2].ToString() == score.ToString()))
            {
                Instantiate(win.gameObject);
            }
            else
            {
                Instantiate(lose.gameObject);

            }
        }

    }

    // Update is called once per frame
    void Update () {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "gameOverScene")
        {
            first.text = "1 - " + scoreArray[0].ToString();
            second.text = "2 - " + scoreArray[1].ToString();
            third.text = "3 - " + scoreArray[2].ToString();
            yours.text = score.ToString();
        }
        else
        {
                 timeFromStart += Time.deltaTime;
        }
    }

    

    public void gameOver()
    {
        numberOfRotations = chooseQuarter.quartersCount / 4;
        score += numberOfRotations;
        shotFired = sphereControler.shotsCount;
        score += shotFired;
        score += (int)timeFromStart;
        updateScoreBoard();
        if (!myflg) {
            myflg = true;
        StartCoroutine(ChageAndExplode());
        }

    }
    public IEnumerator ChageAndExplode()
    {
        Instantiate(explosion, ufo.position, Quaternion.identity);
        ufo.localScale = Vector3.zero;
        ufo.GetComponent<HealthManager>().destroyed = true;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("gameOverScene");
    }
    private void updateScoreBoard()
    {
        scoreArray.Add(score);
        scoreArray.Sort();
        scoreArray.Reverse();
    }
}
