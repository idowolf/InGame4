using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1DialogManager : MonoBehaviour
{
    public DialogManager dialogManager;
    public ChooseQuarter quarterManager;
    public AudioSource[] sounds;
    float time;
    bool flg, flg2, flg3, flg4,flg5,flgnew;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (!flg)
        {
            flg = true;
            dialogManager.ShowText("LEADER 1", "We can't destroy them,\nbut our blasters slow them down.", sounds[0].clip.length);
            Instantiate(sounds[0].gameObject);
        }
        if(time > 2.5f && !flg2)
        {
            flg2 = true;
            dialogManager.ShowText("LEADER 1", "Keep shooting!", 1);

        }
        if (quarterManager.quartersCount == 9 && !flg3)
        {
            flg3 = true;
            dialogManager.ShowText("LEADER 1", "Great shot!", sounds[1].clip.length);
            Instantiate(sounds[1].gameObject);
        }
        if (quarterManager.quartersCount == 13 && !flgnew)
        {
            flgnew = true;
            dialogManager.ShowText("LEADER 1", "Mind the life bar!When it runs out, the UFO will enter Earth!", sounds[2].clip.length);
            Instantiate(sounds[2].gameObject);
        }
        if (quarterManager.quartersCount == 18 && !flg4)
        {
            flg4 = true;
            dialogManager.ShowText("LEADER 1", "It's starting to move around like crazy!\nStay on target!!", sounds[3].clip.length);
            Instantiate(sounds[3].gameObject);
        }
        if (quarterManager.quartersCount == 27 && !flg5)
        {
            flg5 = true;
            dialogManager.ShowText("LEADER 1", "Great shot!", sounds[1].clip.length);
            Instantiate(sounds[1].gameObject);
        }
    }
}
