using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Target
{
    TOP,
    BOTTOM,
    MIDDLE
}
public class YAxisMovement : MonoBehaviour {
    private float yTarget;
    public float targetX, targetZ;
    private Target target;
    public float speed = 0.1f;
    Vector3 eu;
	// Use this for initialization
	void Start () {
        yTarget = 0;
        target = Target.MIDDLE;
        eu = SetRotationEuler();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 target = new Vector3(transform.localPosition.x, yTarget, transform.localPosition.z);
        Debug.Log(Vector3.Distance(transform.localPosition, target));

        if (Vector3.Distance(transform.localPosition, target) < 0.3f)
        {
            eu = SetRotationEuler();
        }
        else
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition,
                target,
                speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
            eu = transform.localEulerAngles;
            eu.y += 90;
        }

        transform.localEulerAngles = eu;
    }
    Vector3 SetRotationEuler()
    {
        Vector3 rotationEuler = new Vector3();
        rotationEuler.y = 90;
        switch (target)
        {
            case Target.TOP:
                rotationEuler.x = 0;
                rotationEuler.z = -10;
                break;
            case Target.MIDDLE:
                rotationEuler.x = 0;
                rotationEuler.z = 0;
                break;
            case Target.BOTTOM:
                rotationEuler.x = 0;
                rotationEuler.z = 10;
                break;
        }
        return rotationEuler;
    }
    public void SetYTarget(Target target)
    {
        this.target = target;
        switch (target)
        {
            case Target.TOP:
                yTarget = 2;
                break;
            case Target.MIDDLE:
                yTarget = 0;
                break;
            case Target.BOTTOM:
                yTarget = -2;
                break;
        }
    }
}
