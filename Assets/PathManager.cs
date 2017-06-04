using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour {
    private List<Transform> targets;
    public int pathObjectsCreated;
    public bool lineVisible;

    // Use this for initialization
    void Awake () {
        populateList();
        if (lineVisible)
        {
            drawLine();
        }
    }

    public void drawLine()
    {
        GameObject newLine = new GameObject("Line");
        LineRenderer lineRenderer = newLine.AddComponent<LineRenderer>();
        lineRenderer.startWidth = lineRenderer.endWidth = transform.localScale.y;
        lineRenderer.positionCount = targets.Count + 1;
        lineRenderer.material.color = Color.red;

        for (int i = 0; targets != null && i < targets.Count; ++i)
        {
            lineRenderer.SetPosition(i, new Vector3(targets[i].transform.position.x, targets[i].transform.position.y, targets[i].transform.position.z));
        }
        lineRenderer.SetPosition(targets.Count, new Vector3(targets[0].transform.position.x, targets[0].transform.position.y, targets[0].transform.position.z));

    }

    private void populateList()
    {
        targets = new List<Transform>();
        pathObjectsCreated = 0;
        //current + startingPoint = startingPoint;
        foreach (Transform child in transform)
        {
            targets.Add(child);
            child.gameObject.GetComponent<PathObjectScript>().pathObjectId = pathObjectsCreated;
            pathObjectsCreated++;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}

    public List<Transform> GetTargetsList()
    {
        return new List<Transform>(targets);
    }

    //public void OnDrawGizmos()
    //{
    //    populateList();
    //    //if (!Application.isPlaying)
    //    //{
    //    //    transform.position = targets[0].position;
    //    //}
    //    Gizmos.color = Color.green;

    //    for (int i = 1; targets != null && i < targets.Count; ++i)
    //    {
    //        Gizmos.DrawLine(targets[i - 1].position, targets[i].position);
    //    }

    //}
}
