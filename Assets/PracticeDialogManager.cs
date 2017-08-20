using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PracticeDialogManager : MonoBehaviour
{
    public static string levelText, levelName;
    public DialogManager dialogManager;
    float time;
    bool flg, flg2, flg3, flg4;
    public AudioSource[] sounds;
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
            dialogManager.ShowText("LEADER 1", levelText, sounds[0].clip.length);
            Instantiate(sounds[0].gameObject);
        }
        if (time > sounds[0].clip.length + 1)
        {
            SceneManager.LoadScene(levelName);
        }
    }

    public static void SetNameAndLevel(string talk, string name)
    {
        levelText = talk;
        levelName = name;
    }
}
