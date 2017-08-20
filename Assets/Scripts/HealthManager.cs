using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
    public Slider healthSlider;
    private float timeFromStart, sliderMax;
    public float timeToGiveOnShot, duration;
    private bool flg;
    public bool destroyed;
    public ScoreManager scoreManager;
	// Use this for initialization
	void Start () {
        healthSlider.value = sliderMax = 100;
        timeFromStart = 0;
	}
	
	// Update is called once per frame
	void Update () {
        healthSlider.value -= (sliderMax * (Time.deltaTime / duration));
        if (healthSlider.value <= 0 && !flg)
        {
            flg = true;
            healthSlider.value = 0;
            if (GetComponent<ChooseQuarter>())
                scoreManager.gameOver();
            else if (GetComponent<LevelChooseQuarter>())
            {
                RetryButton.nextScene = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene("Failure");
            }
        }
    }

    public void giveLife()
    {
        if(!destroyed)
            healthSlider.value += sliderMax * (timeToGiveOnShot / duration);
    }
}
