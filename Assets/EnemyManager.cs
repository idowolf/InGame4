using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public int totalCubesCreated = 0;
    private List<Transform> displayedChildren;
    private List<Transform> enemies;
    public bool waveMode;
    public int objectsOnScreen;
    private int waveRemaining;
	// Use this for initialization
	void Start () {
        displayedChildren = new List<Transform>();
        enemies = new List<Transform>();
        foreach (Transform child in transform)
        {
            enemies.Add(child);
            child.gameObject.GetComponent<Teleport>().SetID(totalCubesCreated);
            if (totalCubesCreated < objectsOnScreen)
                displayedChildren.Add(child);
            else
                child.gameObject.SetActive(false);
            totalCubesCreated++;
        }
        waveRemaining = objectsOnScreen;
        if (displayedChildren.Count != 0)
            displayedChildren[0].GetComponent<SpriteRenderer>().color = Color.red;

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void childIsMarked(Transform t)
    {
        GetComponent<AudioSource>().Play();
        Transform lastDisplayed = displayedChildren[displayedChildren.Count - 1];

        if (enemies.IndexOf(lastDisplayed) != enemies.Count - 1)
        {
            Transform subsequent = enemies[enemies.IndexOf(lastDisplayed) + 1];
            displayedChildren.Add(subsequent);
            if (!waveMode)
                subsequent.gameObject.SetActive(true);
            else
                waveRemaining--;
        }
        displayedChildren.Remove(t);
        t.gameObject.SetActive(false);
        if(waveMode && waveRemaining == 0 && displayedChildren.Count != 0)
        {
            waveRemaining = objectsOnScreen;
            foreach (Transform child in displayedChildren)
            {
                child.gameObject.SetActive(true);
            }
        }
        if(displayedChildren.Count != 0)
            displayedChildren[0].GetComponent<SpriteRenderer>().color = Color.red;

    }
}
