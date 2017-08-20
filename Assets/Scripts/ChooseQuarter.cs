using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ChooseQuarter : MonoBehaviour {

    GameObject [,,] quartersArray;
    public int quartersCount;
    int currQuarter, difficulty;
    GameObject currentPattern,nextPattern;
    //public Text qurterText;
    public enum RotationSide { left, right };
    public RotationSide rotationSide;
    public enum QuarterIndx { A, B, C };
    public QuarterIndx quarterIndx;
    bool dontChangeQuarter;

    public Material[] skyBoxes;
    int skyBoxIterator;



    public float timeFromStart;
	// Use this for initialization
	void Start () {
        timeFromStart = 0;
        skyBoxIterator = 0; 
        difficulty = 0;
        dontChangeQuarter = false;
        quartersArray = new GameObject[3,4,4];
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
        quartersArray[0, 3, 0] = Resources.Load("quarter1M") as GameObject;
        quartersArray[0, 3, 1] = Resources.Load("quarter1N") as GameObject;
        quartersArray[0, 3, 2] = Resources.Load("quarter1O") as GameObject;
        quartersArray[0, 3, 3] = Resources.Load("quarter1P") as GameObject;

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
        quartersArray[1, 3, 0] = Resources.Load("quarter2M") as GameObject;
        quartersArray[1, 3, 1] = Resources.Load("quarter2N") as GameObject;
        quartersArray[1, 3, 2] = Resources.Load("quarter2O") as GameObject;
        quartersArray[1, 3, 3] = Resources.Load("quarter2P") as GameObject;

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
        quartersArray[2, 3, 0] = Resources.Load("quarter3M") as GameObject;
        quartersArray[2, 3, 1] = Resources.Load("quarter3N") as GameObject;
        quartersArray[2, 3, 2] = Resources.Load("quarter3O") as GameObject;
        quartersArray[2, 3, 3] = Resources.Load("quarter3P") as GameObject;

        skyBoxes = new Material[4];
        skyBoxes[0] = (Material)Resources.Load("sb1");
        skyBoxes[1] = (Material)Resources.Load("sb2");
        skyBoxes[2] = (Material)Resources.Load("sb3");
        skyBoxes[3] = (Material)Resources.Load("sb4");
        rotationSide = RotationSide.right;
        currentPattern = Instantiate(quartersArray[0, 0, 0]);
        nextPattern = quartersArray[1, 0, Random.Range(0, 4)];

        currQuarter = 2;
        quartersCount = 2;
        GetComponent<MoveTowardsObject>().SetPattern(currentPattern.transform, rotationSide == RotationSide.right);
        quarterIndx = QuarterIndx.C;
        


    }

    // Update is c alled once per frame
    void Update () {
        //timeFromStart += Time.deltaTime;
        //string myPath = AssetDatabase.GetAssetPath(currentPattern);
        //Debug.Log(myPath);
        
	}

    public void setNextPattren()
    {
        int i = Random.Range(0,4);
        Destroy(currentPattern);
        currentPattern = Instantiate(nextPattern);
        Debug.Log("current quarter is: " + currQuarter + " difficlty  is: " + difficulty + " quarter index is: " + i);
        
        //qurterText.text = "current quarter is: " + currQuarter + "\ndifficlty  is: " + difficulty + "\nquarter index is: " + i;

        nextPattern = quartersArray[(int)quarterIndx,difficulty,i];
        quartersCount++;
        currQuarter++;
        currQuarter %= 3;
        quarterIndx = updateQuarterIndex();
        if (quartersCount == 9 || quartersCount == 18 || quartersCount == 27)
        {
            increaseDifficulty();
        }
        GetComponent<MoveTowardsObject>().SetPattern(currentPattern.transform, rotationSide == RotationSide.right);
        if (quartersCount % 15 == 0)
        {
            changeSide();
            changeSkyBox();
            dontChangeQuarter = true;
        }
               
    }

    public void increaseDifficulty()
    {
        if (difficulty + 1 < quartersArray.GetLength(1))
            difficulty++;
    }

    public void decreaseDifficulty()
    {
        if (difficulty - 1 >= 0)
            difficulty--;
    }

    public void changeSide()
    {
        rotationSide = (rotationSide == RotationSide.right) ?
            RotationSide.left :
            RotationSide.right;
    }

    public QuarterIndx updateQuarterIndex()
    {
        if (dontChangeQuarter) {
            dontChangeQuarter = false;
            return quarterIndx;
        }

        if (rotationSide == RotationSide.right)
        {
            if (quarterIndx == QuarterIndx.A)
            {
                return QuarterIndx.B;
            }
            if (quarterIndx == QuarterIndx.B)
            {
                return QuarterIndx.C;
            }else
            {
                return QuarterIndx.A;
            }
        }
        else
        {
            if (quarterIndx == QuarterIndx.A)
            {
                return QuarterIndx.C;
            }
            if (quarterIndx == QuarterIndx.B)
            {
                return QuarterIndx.A;
            }
            else
            {
                return QuarterIndx.B;
            }
        }
        
    }

    public void changeSkyBox()
    {
        if (skyBoxIterator >= skyBoxes.Length - 1) { skyBoxIterator = -1; }
        RenderSettings.skybox = skyBoxes[++skyBoxIterator];
    }


}
