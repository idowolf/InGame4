using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum axis
{
    X,
    Y,
    Z
}
public class NewerRotate : MonoBehaviour {
    public Transform targetTransform;
    private Vector3 angle;
    public axis axis;
    public float speed;
    // Use this for initialization
    void Start () {
        switch (axis)
        {
            case axis.X:
                angle = new Vector3(1, 0 , 0) * speed;
                break;
            case axis.Y:
                angle = new Vector3(0, 1, 0) * speed;
                break;
            case axis.Z:
                angle = new Vector3(0, 0, 1) * speed;
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
        var targetPosition = targetTransform.position;
        switch (axis)
        {
            case axis.X:
                targetPosition.x = transform.position.x;
                break;
            case axis.Y:
                targetPosition.y = transform.position.y;
                break;
            case axis.Z:
                targetPosition.z = transform.position.z;
                break;
        }
        transform.LookAt(targetPosition);
    }
}
