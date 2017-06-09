using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour {
    public Transform enemyUI;
    private float maxLifeTime;
	// Use this for initialization
	void Start () {
        maxLifeTime = 0;
        Destroy(gameObject, 6.0f);
        enemyUI = GameObject.Find("EnemyUI").transform;
	}
	
	// Update is called once per frame
	void Update () {
        maxLifeTime += Time.deltaTime;
        float thisX = this.transform.position.x;
        float otherX = enemyUI.position.x;
        if ((int)thisX == (int)otherX)
        {
            Destroy(this,0.2f);
            Debug.Log("destroyed!");
        }
	}
}
