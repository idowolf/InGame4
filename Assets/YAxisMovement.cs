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
        transform.localPosition = Vector3.MoveTowards(transform.localPosition,
            new Vector3(transform.localPosition.x,yTarget,transform.localPosition.z),
            speed * Time.deltaTime);
    }

    public void SetYTarget(float yTarget)
    {
        this.yTarget = yTarget;
    }
}
