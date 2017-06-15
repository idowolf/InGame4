using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour {
    public GameObject enemyCarrier;
    public int distanceFromCarrier;
    public Transform obstaclePreFab;
    
    
    private float fiveSecTimer, timeFromStart;

	// Use this for initialization
	void Start () {
        dataUpdate();
        fiveSecTimer = 0;
        timeFromStart = 0;
	}
	
	// Update is called once per frame
	void Update () {
        dataUpdate();

        timeFromStart += Time.deltaTime;
        fiveSecTimer += Time.deltaTime;
        if (((int)fiveSecTimer == 5) && (timeFromStart > 7))
        {
            fiveSecTimer = 0;
            deployObstacle(Random.Range(1, 4));
        }
	}
    void dataUpdate()
    {
        this.GetComponent<EnemyPath>().speed = enemyCarrier.GetComponent<EnemyPath>().speed;
        this.GetComponent<EnemyPath>().current = (enemyCarrier.GetComponent<EnemyPath>().current + distanceFromCarrier) % 40 ;
    }

    void deployObstacle(int num)
    {
        num = Random.Range(1, 4);
        Vector3 pos = this.GetComponent<Transform>().position;
        pos += new Vector3(0, 0, 1);
        if (num == 1)
        {
            pos.y = .45f;
        }
        if (num == 2)
        {
            pos.y = 1.80f;
        }
        if (num == 3)
        {
            pos.y = 3.25f;
        }
        Debug.Log(num + "! this is num");
        Debug.Log("position is: " + pos);
        Instantiate(obstaclePreFab, pos, Quaternion.identity);
        
        
    }
}
