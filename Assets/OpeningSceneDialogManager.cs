using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningSceneDialogManager : MonoBehaviour {
    public DialogManager dialogManager;
    float time;
    bool flg,flg2,flg3,flg4;
    public AudioSource[] sounds;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time > 1.5f && !flg)
        {
            flg = true;
            dialogManager.ShowText("LEADER 1", "ALL UNITS!\nSTAY ON TARGET!",sounds[0].clip.length);
            Instantiate(sounds[0].gameObject);
        }
        if (time > 5 && !flg2)
        {
            flg2 = true;
            dialogManager.ShowText("LEADER 2", "3 SHIPS DOWN!", sounds[1].clip.length);
            Instantiate(sounds[1].gameObject);

        }
        if (time > 5 + sounds[1].clip.length && !flg3)
        {
            flg3 = true;
            dialogManager.ShowText("LEADER 2", "WE NEED BACKUP!", sounds[2].clip.length);
            Instantiate(sounds[2].gameObject);
        }
        if (time > 5 + sounds[1].clip.length + sounds[2].clip.length + 1 && !flg4)
        {
            flg4 = true;
            dialogManager.ShowText("LEADER 1", "ROOKIE!\nPREPARE TO CHASE THIS UFO!", sounds[3].clip.length);
            Instantiate(sounds[3].gameObject);
        }
        if (time > 5 + sounds[1].clip.length + sounds[2].clip.length + sounds[3].clip.length + 1)
        {
            SceneManager.LoadScene("level1");
        }
    }
}
