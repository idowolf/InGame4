using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ChooseQuarter : MonoBehaviour {
    public Behaviour halo;
    public List<Color> ufoColors;
    GameObject [,,] quartersArray;
    public int quartersCount;
    int currQuarter, difficulty;
    GameObject currentPattern,nextPattern,currentPatternII;
    //public Text qurterText;
    public enum RotationSide { left, right };
    public RotationSide rotationSide;
    public enum QuarterIndx { A, B, C };
    public QuarterIndx nextQuarterIndx;
    bool dontChangeQuarter;
    public GameObject explosionPrefab;
    private Vector3 initScale;
    public Material[] skyBoxes;
    int skyBoxIterator;
    private bool resize;

    private float initMovementSpeed;
    public float timeFromStart;
	// Use this for initialization
	void Start () {
        initScale = transform.localScale;
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
        nextQuarterIndx = QuarterIndx.C;
        initMovementSpeed = GetComponent<MoveTowardsObject>().movementSpeed;


    }

    // Update is c alled once per frame
    void Update () {
        //timeFromStart += Time.deltaTime;
        //string myPath = AssetDatabase.GetAssetPath(currentPattern);
        //Debug.Log(myPath);

        //Fade Out the screen to black
        if (fadingNow)
        {
            fadeElapsed += Time.deltaTime;
            //When the Async is finished, the level is done loading, fade in the screen
            if (fadeElapsed >= fadeTime)
            {
                fadeElapsed = 0;
                fadingNow = false;
                FadeIn();
            }
        }

        if (fadeout)
        {
            myImage.color = Color.Lerp(myImage.color, Color.black, fadeSpeed * Time.deltaTime);

            //Once the Black image is visible enough, Start loading the next level
            if (myImage.color.a >= 0.999)
            {
                StartCoroutine("LoadALevel");
                fadeout = false;
            }
        }
        if (resize)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, initScale, 0.7f * Time.deltaTime);

            //Once the Black image is visible enough, Start loading the next level
            if (Vector3.Distance(transform.localScale,initScale) < 0.0001f)
            {
                resize = false;
                halo.enabled = true;
            }
        }
        if (fadein)
        {
            myImage.color = Color.Lerp(myImage.color, new Color(0, 0, 0, 0), fadeSpeed * Time.deltaTime);

            if (myImage.color.a <= 0.01)
            {
                fadein = false;
            }
        }
    }

    public void setNextPattren()
    {
        if(quartersCount < 6)
        {
            GetComponent<MoveTowardsObject>().movementSpeed = 10;
        }
        else
        {
            GetComponent<MoveTowardsObject>().movementSpeed = initMovementSpeed;
        }
        int i = Random.Range(0,4);
        currentPatternII = Instantiate(currentPattern);
        Destroy(currentPattern);
        currentPattern = Instantiate(nextPattern);
        //Debug.Log("current quarter is: " + currQuarter + " difficlty  is: " + difficulty + " quarter index is: " + i);
        
        //qurterText.text = "current quarter is: " + currQuarter + "\ndifficlty  is: " + difficulty + "\nquarter index is: " + i;

        nextPattern = quartersArray[(int)nextQuarterIndx,difficulty,i];
        quartersCount++;
        currQuarter++;
        currQuarter %= 3;
        nextQuarterIndx = updateQuarterIndex();
        if (quartersCount == 9 || quartersCount == 18 || quartersCount == 27)
        {
            increaseDifficulty();
        }
        if (quartersCount % 15 == 0)
        {
            changeSide();
            changeSkyBox();
            nextPattern = currentPatternII;
            nextQuarterIndx = updateQuarterIndex();
        }
        GetComponent<MoveTowardsObject>().SetPattern(currentPattern.transform, rotationSide == RotationSide.right);


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
        ResizeMe();
    }

    public void ResizeMe()
    {
        Vector3 explosionPos = Camera.main.ScreenToWorldPoint(new Vector3(UnityEngine.VR.VRSettings.eyeTextureWidth / 2, UnityEngine.VR.VRSettings.eyeTextureHeight / 2, 13));
        Instantiate(explosionPrefab, explosionPos, Quaternion.identity);
        resize = true;
        transform.localScale = Vector3.zero;
        GameObject.Find("UFO_Hull").GetComponent<IterateColors>().NextColor();
        halo.enabled = false;
    }

    public QuarterIndx updateQuarterIndex()
    {
       
        if (rotationSide == RotationSide.right)
        {
            if (nextQuarterIndx == QuarterIndx.A)
            {
                return QuarterIndx.B;
            }
            if (nextQuarterIndx == QuarterIndx.B)
            {
                return QuarterIndx.C;
            }else
            {
                return QuarterIndx.A;
            }
        }
        else
        {
            if (nextQuarterIndx == QuarterIndx.A)
            {
                return QuarterIndx.C;
            }
            if (nextQuarterIndx == QuarterIndx.B)
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
        FadeOut();
    }

    public Image myImage;
    // Use this for initialization
    public int LevelToLoad;
    public float fadeSpeed = 1.5f, fadeTime;
    private float fadeElapsed;
    private bool fadein, fadeout, fadingNow;


    public void FadeOut()
    {
        fadein = false;
        fadeout = true;
        //Debug.Log("Fading Out");
    }

    public void FadeIn()
    {
        fadeout = false;
        fadein = true;
        //Debug.Log("Fading In");
    }

    public IEnumerator LoadALevel()
    {
        fadingNow = true;
        yield return new WaitForSeconds(fadeTime);
        RenderSettings.skybox = skyBoxes[++skyBoxIterator];
    }
}