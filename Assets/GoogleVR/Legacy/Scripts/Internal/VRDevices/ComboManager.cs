using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour {
	public int ComboLength;
    public GameObject[] animations = new GameObject[5];
    public GameObject ComboText;
    public GameObject player;
    //public float velocityFactor;
    public float baseVelocity, timeElapsed;
    private bool scaleTextSize;
    //private int initTextSize;
    public AudioSource GoodSound;
    public AudioSource GreatSound;
    public AudioSource AwesomeSound;
    public AudioSource OutstadingSound;
    public AudioSource AmaizingSound;
    public AudioSource AwwSound;
    // Use this for initialization
    void Start () {
        GoodSound = GameObject.Find("Good").GetComponent<AudioSource>();
        GreatSound = GameObject.Find("Great").GetComponent<AudioSource>();
        AwesomeSound = GameObject.Find("Awesome").GetComponent<AudioSource>();
        OutstadingSound = GameObject.Find("Outstanding").GetComponent<AudioSource>();
        AmaizingSound = GameObject.Find("Amaizing").GetComponent<AudioSource>();
        //velocityFactor = 1;
        //initTextSize = ComboText.fontSize;
	}


    // Update is called once per frame
    private void LateUpdate() { 
        //if (scaleTextSize)
        //{
        //    timeElapsed += Time.deltaTime;
        //    if ((int)(timeElapsed*100) % 2 == 0)
        //    { 
        //        //ComboText.fontSize++;
        //    }
        //    if(timeElapsed > 3f)
        //    {
        //        timeElapsed = 0;
        //        ComboText.text = "";
        //        ComboText.fontSize = initTextSize;
        //        scaleTextSize = false;
        //    }
        //}
    }

    public void MangaeTheCombo (bool keepCombo)
    {
        // if current ID is the next consecutive collectible after the last one
        if (keepCombo)
        {
            ComboLength ++;
        }
        // else, reset the combo
        else
        {
            ComboLength = 0;
            AwwSound.Play();
            //velocityFactor = 1.0f;
        }
        if (ComboLength == 5)
        {
            //velocityFactor = 1.25f;
            SetComboText(0);
        }
        else if (ComboLength == 10)
        {
            //velocityFactor = 1.50f;
            SetComboText(1);
        }
        else if (ComboLength == 15)
        {
            //velocityFactor = 2.0f;
            SetComboText(2);
        }
        else if (ComboLength == 20)
        {
            //velocityFactor = 2.5f;
            SetComboText(3);
        }
        else if (ComboLength == 25)
        {
            //velocityFactor = 3f;
            SetComboText(4);
        }
 




        //if combo is long enough - player velocity multiply by factor.
        //player.GetComponent<MoveUpwards>().velocity = baseVelocity * velocityFactor;
    }

    private void SetComboText(int streakID)
    {
        if (streakID == 0)
        {
            //ComboText.text = "Good!";
            playSoundGood();
        }

        else if (streakID == 1)
        {
            //ComboText.text = "Great!!";
            playSoundGreat();
        }

        else if (streakID == 2)
        {
            //ComboText.text = "Awesome!";
            playSoundAwesome();
        }

        else if (streakID == 3)
        {
            //ComboText.text = "Outstanding";
            playSoundOutstanding();
        }
        else if (streakID == 4)
        {
            //ComboText.text = "Amaizing";
            playSoundAmaizing();
        }
        GameObject.Instantiate(animations[streakID], ComboText.transform.position, ComboText.transform.rotation);
    }



    void playSoundGood()
    {
        GoodSound.Play();
    }
    void playSoundGreat()
    {
        GreatSound.Play();
    }
    void playSoundAwesome()
    {
        AwesomeSound.Play();
    }
    void playSoundOutstanding()
    {
        OutstadingSound.Play();
    }
    void playSoundAmaizing()
    {
        AmaizingSound.Play();
    }






}
