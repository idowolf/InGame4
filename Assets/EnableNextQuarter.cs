using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableNextQuarter : MonoBehaviour {
    public GameObject nextQuarter;
    public float quarterSpeed = 1;
	// Use this for initialization
	void Start () {
		foreach(Transform child in transform)
        {
            child.GetComponent<SphereController>().comingToYouSpeed = quarterSpeed;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.childCount <= 1)
        {
            if(nextQuarter)
                nextQuarter.SetActive(enabled);
        }
	}
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
