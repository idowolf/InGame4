using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour {

    public static int LastInCombo;
	public static int ComboLength;
    public Text ComboText;
    public GameObject player;
    public float velocityFactor;
    public float baseVelocity;
    // Use this for initialization
    void Start () {
        LastInCombo = 0;
        baseVelocity = player.GetComponent<MoveUpwards>().velocity;
        velocityFactor = 1;
        NullifyComboSize(-1);
	}
	
	
    // Update is called once per frame
	void Update () {
    }

    public void MangaeTheCombo (int ID)
    {
        if (ID > LastInCombo)
        {
            ComboLength += ID - LastInCombo;
            LastInCombo = ID;
        }

        ComboText.text = "TOBIS-2005";
        if ((ComboLength >= 5) && (ComboLength < 15))
        {
            velocityFactor = 1.25f;
            ComboText.text = "Niceee";
        }
        else if ((ComboLength >= 15) && (ComboLength < 30))
        {
            velocityFactor = 1.50f;
            ComboText.text = "Awesomeee";
        }
        else if (ComboLength >= 30)
        {
            velocityFactor = 2.0f;
            ComboText.text = "Killing Spree!!";
        }
        else
        {
            velocityFactor = 1.0f;
            ComboText.text = "";
        }
        //if combo is long enough - player velocity multiply by factor.
        player.GetComponent<MoveUpwards>().velocity = baseVelocity * velocityFactor;

    }

    public void NullifyComboSize(int ID)
    {
        ComboLength = 0;
        LastInCombo = ID + 1;
    }
}
