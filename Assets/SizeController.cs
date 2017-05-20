using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeController : MonoBehaviour {

    public float twoSecondsTimer;
    private Vector3 sizeVector = new Vector3();
    public bool isTouched;
    public GameObject ExplosionPrefab;
    private float scalseAtStart ;
    private float scaleFactor;

    // Use this for initialization
    void Start()
    {
        scalseAtStart = transform.localScale.x;
        twoSecondsTimer = 0;

    }
	
	// Update is called once per frame
	void Update () {
        if (twoSecondsTimer >= 2f)
        {
            Debug.Log("bigger than 2");
            GameObject.Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        }
        if (isTouched)
        {
            if (twoSecondsTimer > 0) { twoSecondsTimer -= Time.deltaTime; }
        }else
        {
            twoSecondsTimer += Time.deltaTime;
        }
        setScale();
	}

    void setScale()
    {
        scaleFactor = 1 + (twoSecondsTimer / 2);
        transform.localScale = scalseAtStart * new Vector3(scaleFactor,scaleFactor,scaleFactor);
    }
    
}
