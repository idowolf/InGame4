using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    //public GameObject obj;
    public int multiFactor;
    public int score;
    float altAtStart;
    private Vector3 startingPosition;
    public Text scoreText;

    // Use this for initialization
    void Start () {
        score = 0;
        startingPosition = transform.localPosition;
        altAtStart = startingPosition.y;
    }

    // Update is called once per frame
    void Update () {
        //score += (int)(transform.obj.y - altAtStart);
		scoreText.text = "Score: " + Mathf.Round(score);
    }
}
