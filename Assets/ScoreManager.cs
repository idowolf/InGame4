using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour {

    public GameObject scoreObj, square, m_Lives;
    public Transform ui_root;
    public int multiFactor;
    public int score, lives;
    float altAtStart;
    private Vector3 startingPosition;
    public Text scoreText;
    float height, width, partialHeight;


    // Use this for initialization
    void Start () {
        score = 0;
        startingPosition = transform.position;
        altAtStart = startingPosition.y;
        //lives = 3;
        printLives();
    }

    // Update is called once per frame
    void Update () {
        
        score += (int)(Mathf.Abs(scoreObj.transform.position.y - altAtStart));
        scoreText.text = "SCORE: " + Mathf.Round(score);

#if UNITY_EDITOR
        width = Screen.width ;
        height = Screen.height ;
#else
        width = UnityEngine.VR.VRSettings.eyeTextureWidth ;
        height = UnityEngine.VR.VRSettings.eyeTextureHeight ;

#endif
        partialHeight = (height * 60 / 100);
        if (square.transform.position.y <= partialHeight)
        {
            lives--;
        }
        if (lives == 0 )
        {
            //GAMEOVER!!!
            //SceneManager.LoadScene(gameOverScene);
            //scoreText.text = "Score: " + Mathf.Round(score);
        }
        else
        {
            printLives();
        }
    }

    void printLives()
    {
        for (int i = 0; i < lives; i++)
        {
            GameObject life = GameObject.Instantiate(m_Lives);
            life.transform.parent = ui_root;
            life.transform.localPosition = new Vector3(i * 2, 0f, 0f);

        }
    }
}
