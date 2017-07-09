using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsObject : MonoBehaviour {
    public Transform pattern;
    public float movementSpeed, rotationSpeed;


    public Queue<Vector3> targets;
    private int childIndex;
    private Vector3 rotationAxis;
	// Use this for initialization
	void Start () {
        rotationAxis = new Vector3(0, rotationSpeed, 0);
        targets = new Queue<Vector3>();
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
        if(childIndex < pattern.childCount)
        {
            targets.Enqueue(pattern.GetChild(childIndex).position);
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
        this.pattern = pattern;
        ProbeParent();
    }
}
