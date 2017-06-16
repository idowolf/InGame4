using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class EnemyPath : MonoBehaviour
{
    public Transform path;
    public int pathRotation;
    private List<Transform> targets;
    public float speed;
    public bool loop;
    public bool faceAway;
    public int current;
    public bool goBackwardsOnPath;
    private void Start()
    {
        targets = new List<Transform>();
        //current + startingPoint = startingPoint;
        foreach (Transform child in path)
            targets.Add(child);
        if (goBackwardsOnPath)
            targets.Reverse();
    }
    public void OnDrawGizmos()
    {
        Start();
        if (!Application.isPlaying)
        {
            transform.position = targets[0].position;
        }
        Gizmos.color = Color.green;

        for (int i = 1; targets != null && i < targets.Count; ++i)
        {
            Gizmos.DrawLine(targets[i - 1].position, targets[i].position);
        }

    }

    private void Update()
    {
        if (current < targets.Count && transform.position != targets[current].position)
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
            current++;
            if(loop)
                current %= targets.Count;
        }
    }

}
