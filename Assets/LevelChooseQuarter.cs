using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChooseQuarter : MonoBehaviour
{
    [System.Serializable]
    public class Data
    {
        public GameObject pattern;
        public bool rotatingLeft;
    }
    public Data[] patternList;

    private int index;
    public void setNextPattren()
    {
        if(index < patternList.Length)
        {
            GetComponent<MoveTowardsObject>().SetPattern(patternList[index].pattern.transform, !patternList[index].rotatingLeft);
            index++;
        }
        else
        {
            SceneManager.LoadScene("Success");
        }
    }
}