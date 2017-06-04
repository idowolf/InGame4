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
    // Use this for initialization
    void Start () {
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
            //velocityFactor = 1.0f;
        }
        //if combo is long enough - player velocity multiply by factor.
        //player.GetComponent<MoveUpwards>().velocity = baseVelocity * velocityFactor;
    }
}
