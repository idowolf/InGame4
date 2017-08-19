using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsObject : MonoBehaviour {
    public Transform pattern;
    public float movementSpeed, rotationSpeed;


    public Queue<Vector3> targets;
    private int childIndex;
    private Vector3 rotationAxis;
    private bool rightRotation;
	// Use this for initialization
	void Start () {
        rotationAxis = new Vector3(0, rotationSpeed, 0);
        targets = new Queue<Vector3>();
        rightRotation = true;
    }
	
	// Update is called once per frame
	void Update ()
    {

        if(targets.Count > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, targets.Peek(), movementSpeed * Time.deltaTime);
            transform.Rotate(rotationAxis);
            if(Vector3.Distance(transform.position, targets.Peek()) < 0.1f)
            {
                targets.Dequeue();
            }
        }
	}

    public void ProbeParent()
    {
        if(rightRotation && childIndex < pattern.childCount)
        {
            targets.Enqueue(pattern.GetChild(childIndex).position);
            childIndex++;
        }
        else if ((!rightRotation) && childIndex >= 0)
        {
            targets.Enqueue(pattern.GetChild(childIndex).position);
            childIndex--;
        }
        else
        {
            GetComponent<ChooseQuarter>().setNextPattren();
        }
    }
    public void SetPattern(Transform pattern, bool rightRotation)
    {
        this.pattern = pattern;
        this.rightRotation = rightRotation;
        childIndex = rightRotation ? 0 : pattern.childCount - 1;
        ProbeParent();
    }
}