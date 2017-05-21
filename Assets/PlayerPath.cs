using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerPath : MonoBehaviour
{
    public int currentTarget;
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
    private void Start()
    {
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
        if (current != currentTarget && transform.position != targets[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, targets[current].position, speed * Time.deltaTime);
            if (faceAway)
                transform.rotation = Quaternion.LookRotation(Camera.main.transform.position - transform.position);
            else
                transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);

            GetComponent<Rigidbody>().MovePosition(pos);
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

}
