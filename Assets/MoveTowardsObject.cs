using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsObject : MonoBehaviour {
    public Transform pattern;
    public float movementSpeed, rotationSpeed;


    private Transform target;
    private bool reached;
    private int childIndex;
    private Vector3 rotationAxis;
	// Use this for initialization
	void Start () {
        reached = true;
        rotationAxis = new Vector3(0, rotationSpeed, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {

        if(!reached)
        {
            if (target)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
                transform.Rotate(rotationAxis);
                reached = Vector3.Distance(transform.position, target.position) < 0.1f;
            }
        }
	}
    public void SetTarget(Transform target)
    {
        this.target = target;
    }
    public void ProbeParent()
    {
        if(childIndex < pattern.childCount)
        {
            reached = false;
            target = pattern.GetChild(childIndex);
            childIndex++;
        }
        else
        {
            GetComponent<ChooseQuarter>().setNextPattren();
        }
    }
    public void SetPattern(Transform pattern)
    {
        childIndex = 0;
        reached = true;
        this.pattern = pattern;
        ProbeParent();
    }
}
