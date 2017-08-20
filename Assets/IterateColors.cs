using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IterateColors : MonoBehaviour {
    public List<Color> colors;
    private int index;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextColor()
    {
        index++;
        if (index >= colors.Count) index = 0;
        GetComponent<Renderer>().material.SetColor("_Color", colors[index]);
    }
}
