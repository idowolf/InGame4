using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerPath : MonoBehaviour
{
    public float distance;
    public int currentTarget;
    public bool[] circlePoints;
    public int pathObjectsCreated;
    public Transform path;
    public int pathRotation;
    private List<Transform> targets;
    public float speed;
    public bool loop;
    public bool faceAway;
    public int current;
    public bool goBackwardsOnPath;
    public static bool allowMovement;
    public LineRenderer lineRenderer;
    public int roundCount;
    public string tagToSearch;
    public Text text;
    public StatsManager statsManager;
    
    private void Start()
    {
        roundCount = 0;
        targets = new List<Transform>();
        //current + startingPoint = startingPoint;
        foreach (Transform child in path)
        { 
            targets.Add(child);
            child.gameObject.GetComponent<PathObjectScript>().pathObjectId = pathObjectsCreated;
            pathObjectsCreated++;
        }
        if (goBackwardsOnPath)
            targets.Reverse();
        GameObject newLine = new GameObject("Line");
        lineRenderer.startWidth = 0.5f;
        lineRenderer.endWidth = 0.5f;
        lineRenderer.positionCount = targets.Count + 1;
        lineRenderer.material.color = Color.red;

        for (int i = 0; targets != null && i < targets.Count; ++i)
        {
            lineRenderer.SetPosition(i, new Vector3(targets[i].transform.position.x, targets[i].transform.position.y, targets[i].transform.position.z));
        }
        lineRenderer.SetPosition(targets.Count, new Vector3(targets[0].transform.position.x, targets[0].transform.position.y, targets[0].transform.position.z));
        circlePoints = new bool[targets.Count];
    }
    public void OnDrawGizmos()
    {
        //Start();
        //if (!Application.isPlaying)
        //{
        //    transform.position = targets[0].position;
        //}
        //Gizmos.color = Color.green;

        //for (int i = 1; targets != null && i < targets.Count; ++i)
        //{
        //    Gizmos.DrawLine(targets[i - 1].position, targets[i].position);
        //}

    }

    private void Update()
    {
        transform.position = Camera.main.transform.position + Camera.main.transform.forward * distance;
        transform.rotation = Quaternion.LookRotation((Camera.main.transform.position - transform.position) * (faceAway ? 1 : -1));

        if (current != currentTarget && transform.position != targets[current].position)
        {
            //Vector3 pos = Vector3.MoveTowards(transform.position, targets[current].position, speed * Time.deltaTime);

            //GetComponent<Rigidbody>().MovePosition(pos);
        }
        else
        {
            float myAbs = Mathf.Abs(current - currentTarget);
            int amount = targets.Count;
            bool clockwards = Mathf.Abs(current - currentTarget) < amount / 2 ^ currentTarget < current;
            if (clockwards)
                current++;
            else
                current--;
            if (current < 0)
                current += amount;
            else if (current >= amount)
                current -= amount;
        }
    }

    public void Shout(int i)
    {
        currentTarget = i;
        if (circlePoints[i])
        {
            if(circlePoints.Count(c => c) >= 0.75f * circlePoints.Length)
            { 
                roundCount++;
                circlePoints = new bool[circlePoints.Length];
            }
            text.text = roundCount.ToString();
            if (roundCount >= 20)
                    LoadGameOver(true);
        }
        else
            circlePoints[i] = true;
    }

    public void LoadGameOver(bool yay)
    {
        //update all records and stats
        statsManager.updateRecordTable(yay ? 1 : -1);
        //print table for check
        statsManager.printRecordTable();

        SceneManager.LoadScene("gameOverScene");

    }
}
