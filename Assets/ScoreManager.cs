using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour {

    public GameObject scoreObj, square, m_Lives;
    public Transform ui_root;
    public int multiFactor;
    public int lives;
    public static int score;
    float altAtStart;
    private Vector3 startingPosition;
    public Text scoreText;
    float height, width, partialHeight;
    bool lifeDecreased;

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
        height = scoreObj.transform.position.y;
        partialHeight = (height * 90 / 100);
        scoreText.text = "SCORE: " + Mathf.Round(score);
        if (square.transform.position.y <= partialHeight)
        {
            if (!lifeDecreased)
            {
                lifeDecreased = true;
                lives--;
                removeLives();
                printLives();
                if (lives == 0)
                {
                    //GAMEOVER!!!
                    SceneManager.LoadScene("gameOverScene");
                    //scoreText.text = "Score: " + Mathf.Round(score);
                }
            }
        }
    }

    public void ResetLifeDecreased()
    {
        lifeDecreased = false;
    }
    void removeLives()
    {
        ui_root.transform.localScale = Vector3.one;
        foreach (Transform child in ui_root.transform)
        {
            GameObject.Destroy(child.gameObject);
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
        ui_root.transform.localScale = Vector3.one * 0.2f;
    }
}
