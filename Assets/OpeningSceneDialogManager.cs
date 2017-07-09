using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningSceneDialogManager : MonoBehaviour {
    public DialogManager dialogManager;
    float time;
    bool flg,flg2,flg3,flg4;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time > 3 && !flg)
        {
            flg = true;
            dialogManager.ShowText("LEADER 1", "ALL UNITS!\nSTAY ON TARGET!");
        }
        if (time > 6 && !flg2)
        {
            flg2 = true;
            dialogManager.ShowText("LEADER 2", "3 SHIPS DOWN!",1.5f);
        }
        if (time > 8 && !flg3)
        {
            flg3 = true;
            dialogManager.ShowText("LEADER 2", "WE NEED BACKUP!", 1.5f);
        }
        if (time > 10 && !flg4)
        {
            flg4 = true;
            dialogManager.ShowText("LEADER 1", "ROOKIE!\nPREPARE TO CHASE THIS UFO!", 3);
        }
        if(time > 14)
        {
            AutoFade.LoadLevel("level1", 3, 1, Color.black);
        }
    }
}
