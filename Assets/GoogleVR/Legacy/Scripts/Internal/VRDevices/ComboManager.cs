using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour {

    public static int LastInCombo;
	public static int ComboLength;
    public Text ComboText;
    public GameObject player;
    public float velocityFactor, baseVelocity, timeElapsed;
    private bool scaleTextSize;
    private int initTextSize;
    // Use this for initialization
    void Start () {
        //baseVelocity = player.GetComponent<MoveUpwards>().velocity;
        velocityFactor = 1;
        initTextSize = ComboText.fontSize;
	}
	
	
    // Update is called once per frame
	private void LateUpdate() { 
        if (scaleTextSize)
        {
            timeElapsed += Time.deltaTime;
            if ((int)(timeElapsed*100) % 2 == 0)
            { 
                ComboText.fontSize++;
            }
            if(timeElapsed > 3f)
            {
                timeElapsed = 0;
                ComboText.text = "";
                ComboText.fontSize = initTextSize;
                scaleTextSize = false;
            }
        }
    }

    public void MangaeTheCombo (int ID)
    {
        // if current ID is the next consecutive collectible after the last one
        if (ID - LastInCombo == 1)
        {
            ComboLength ++;
        }
        // else, reset the combo
        else
        {
            ComboLength = 0;
            velocityFactor = 1.0f;
        }
        LastInCombo = ID;
        if (ComboLength == 5)
        {
            velocityFactor = 1.25f;
            SetComboText(0);
        }
        else if (ComboLength == 15)
        {
            velocityFactor = 1.50f;
            SetComboText(1);
        }
        else if (ComboLength == 30)
        {
            velocityFactor = 2.0f;
            SetComboText(2);
        }
        //if combo is long enough - player velocity multiply by factor.
        //player.GetComponent<MoveUpwards>().velocity = baseVelocity * velocityFactor;
    }

    private void SetComboText(int streakID)
    {
        if (streakID == 0)
            ComboText.text = "Nice!";
        else if (streakID == 1)
            ComboText.text = "Awesome!!";
        else
            ComboText.text = "KILLING STREAK!!!";
        scaleTextSize = true;
    }
}
