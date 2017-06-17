using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YAxisMovement : MonoBehaviour {
    private float yTarget;
    public float speed = 0.1f;
	// Use this for initialization
	void Start () {
        yTarget = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 target = new Vector3(transform.localPosition.x, yTarget, transform.localPosition.z);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition,
            target,
            speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
        Vector3 eu = transform.localEulerAngles;
        eu.y += 90;
        transform.localEulerAngles = eu;
    }

    public void SetYTarget(float yTarget)
    {
        this.yTarget = yTarget;
    }
}
