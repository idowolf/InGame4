using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ChooseQuarter : MonoBehaviour {

    GameObject [,,] quartersArray;
    int currQuarter;
    int difficulty;
    public GameObject halalit;
    GameObject currentPattern,nextPattern;
	// Use this for initialization
	void Start () {
        
        difficulty = 0;
        quartersArray = new GameObject[3,3,4];
        quartersArray[0, 0, 0] = Resources.Load("quarter1A") as GameObject;
        quartersArray[0, 0, 1] = Resources.Load("quarter1B") as GameObject;
        quartersArray[0, 0, 2] = Resources.Load("quarter1C") as GameObject;
        quartersArray[0, 0, 3] = Resources.Load("quarter1D") as GameObject;
        quartersArray[0, 1, 0] = Resources.Load("quarter1E") as GameObject;
        quartersArray[0, 1, 1] = Resources.Load("quarter1F") as GameObject;
        quartersArray[0, 1, 2] = Resources.Load("quarter1G") as GameObject;
        quartersArray[0, 1, 3] = Resources.Load("quarter1H") as GameObject;
        quartersArray[0, 2, 0] = Resources.Load("quarter1I") as GameObject;
        quartersArray[0, 2, 1] = Resources.Load("quarter1J") as GameObject;
        quartersArray[0, 2, 2] = Resources.Load("quarter1K") as GameObject;
        quartersArray[0, 2, 3] = Resources.Load("quarter1L") as GameObject;


        quartersArray[1, 0, 0] = Resources.Load("quarter2A") as GameObject;
        quartersArray[1, 0, 1] = Resources.Load("quarter2B") as GameObject;
        quartersArray[1, 0, 2] = Resources.Load("quarter2C") as GameObject;
        quartersArray[1, 0, 3] = Resources.Load("quarter2D") as GameObject;
        quartersArray[1, 1, 0] = Resources.Load("quarter2E") as GameObject;
        quartersArray[1, 1, 1] = Resources.Load("quarter2F") as GameObject;
        quartersArray[1, 1, 2] = Resources.Load("quarter2G") as GameObject;
        quartersArray[1, 1, 3] = Resources.Load("quarter2H") as GameObject;
        quartersArray[1, 2, 0] = Resources.Load("quarter2I") as GameObject;
        quartersArray[1, 2, 1] = Resources.Load("quarter2J") as GameObject;
        quartersArray[1, 2, 2] = Resources.Load("quarter2K") as GameObject;
        quartersArray[1, 2, 3] = Resources.Load("quarter2L") as GameObject;

        quartersArray[2, 0, 0] = Resources.Load("quarter3A") as GameObject;
        quartersArray[2, 0, 1] = Resources.Load("quarter3B") as GameObject;
        quartersArray[2, 0, 2] = Resources.Load("quarter3C") as GameObject;
        quartersArray[2, 0, 3] = Resources.Load("quarter3D") as GameObject;
        quartersArray[2, 1, 0] = Resources.Load("quarter3E") as GameObject;
        quartersArray[2, 1, 1] = Resources.Load("quarter3F") as GameObject;
        quartersArray[2, 1, 2] = Resources.Load("quarter3G") as GameObject;
        quartersArray[2, 1, 3] = Resources.Load("quarter3H") as GameObject;
        quartersArray[2, 2, 0] = Resources.Load("quarter3I") as GameObject;
        quartersArray[2, 2, 1] = Resources.Load("quarter3J") as GameObject;
        quartersArray[2, 2, 2] = Resources.Load("quarter3K") as GameObject;
        quartersArray[2, 2, 3] = Resources.Load("quarter3L") as GameObject;

        currentPattern = Instantiate(quartersArray[0, 0, 0]);
        nextPattern = quartersArray[1, 0, Random.Range(0, 3)];

        currQuarter = 2;


    }

    // Update is c alled once per frame
    void Update () {
		
	}

    public void setNextPattren()
    {
        int i = Random.Range(0,4);
        Destroy(currentPattern);
        currentPattern = Instantiate(nextPattern);
        nextPattern = quartersArray[currQuarter,difficulty,i];
        currQuarter ++;
        currQuarter %= 3;
    }

    public void setDifficulty(int d)
    {
        difficulty = d;
    }


}
