using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour {
    private Vector2[] pts;
    int i;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(pts != null)
        {
            transform.position = pts[i];
            i++;
            if(pts.Length == i)
            {
                pts = null;
            }
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        pts = other.gameObject.GetComponent<PolygonCollider2D>().points;
        i = 0;
    }
}
