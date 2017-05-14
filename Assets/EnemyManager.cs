using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public GameObject ExplosionPrefab;
    public int totalCubesCreated = 0;
    private Transform nextInCombo;
    public List<Transform> enemies;
    public bool waveMode;
    public int objectsOnScreen;
    private int waveRemaining;
    public Sprite comboFairy;
    public ComboManager comboManager;
    public Timer timer;
    // Use this for initialization
    void Start () {
        enemies = new List<Transform>();
        foreach (Transform child in transform)
        {
            enemies.Add(child);
            child.gameObject.GetComponent<Teleport>().SetID(totalCubesCreated);
            if (totalCubesCreated >= objectsOnScreen)
                child.gameObject.SetActive(false);
            totalCubesCreated++;
        }
        waveRemaining = objectsOnScreen;
        setNextInCombo();

    }
    private void setNextInCombo()
    {
        if (enemies.Count != 0)
        {
            enemies[0].GetComponent<SpriteRenderer>().sprite = comboFairy;
            nextInCombo = enemies[0];
        }
        else
            timer.LoadGameOver();

    }
    // Update is called once per frame
    void Update () {
		
	}

    public void childIsMarked(Transform t)
    {
        timer.addTimer(0.5f);
        GameObject.Instantiate(ExplosionPrefab, t.position, t.rotation);
        GetComponent<AudioSource>().Play();
        if (t == nextInCombo)
            comboManager.MangaeTheCombo(true);
        else
            comboManager.MangaeTheCombo(false);


        enemies.Remove(t);
        if (enemies.Count != 0)
        {
            t.gameObject.SetActive(false);
            if (waveMode)
            {
                waveRemaining--;
                if (waveRemaining == 0)
                {
                    waveRemaining = objectsOnScreen;
                    for(int i = 0; i <objectsOnScreen && i < enemies.Count; i++)
                    {
                        enemies[i].gameObject.SetActive(true);
                    }
                }
            }
            else
            {
                if(FirstUndisplayedChild())
                    FirstUndisplayedChild().gameObject.SetActive(true);
            }
        }
        setNextInCombo();
    }
    private Transform FirstUndisplayedChild()
    {
        foreach (Transform t in enemies)
        {
            if (!t.gameObject.activeSelf)
                return t;
        }
        return null;
    }
    private List<Transform> GetDisplayedChildren()
    {
        List<Transform> lst = new List<Transform>();
        foreach (Transform t in enemies)
        {
            if (t.gameObject.activeSelf)
                lst.Add(t);
        }
        return lst;
    }
}
