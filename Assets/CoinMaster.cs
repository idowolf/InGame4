using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMaster : MonoBehaviour {
    public  GameObject enemyCarrier;
    int distanceFromCarrier;

    // Use this for initialization
    void Start () {
        distanceFromCarrier = 10;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void dataUpdate()
    {
        this.GetComponent<EnemyPath>().speed = enemyCarrier.GetComponent<EnemyPath>().speed;
        this.GetComponent<EnemyPath>().current = (enemyCarrier.GetComponent<EnemyPath>().current + distanceFromCarrier) % 40;
    }
}
