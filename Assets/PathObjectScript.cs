using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PathObjectScript : MonoBehaviour {
    public int pathObjectId;
    public PlayerPath playerPath;
	// Use this for initialization
	void Start () {
        EventTrigger trigger = GetComponentInParent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((eventData) => { playerPath.Shout(pathObjectId); });
        trigger.triggers.Add(entry);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
