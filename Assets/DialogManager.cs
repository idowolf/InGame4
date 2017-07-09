using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogManager : MonoBehaviour {
    public GameObject dialogContainer;
    public Text speaker;
    public Text dialog;
    float time, duration;
    bool active;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (active)
        {
            time += Time.deltaTime;
            if(time > duration)
            {
                active = false;
                time = 0;
                dialogContainer.SetActive(false);

            }
        }
	}
    public void ShowText(string speaker, string dialog)
    {
        ShowText(speaker, dialog, 3);
    }
    public void ShowText(string speaker, string dialog, float duration)
    {
        this.speaker.text = speaker;
        this.dialog.text = dialog;
        dialogContainer.SetActive(true);
        this.duration = duration;
        active = true;
        time = 0;
    }
}
