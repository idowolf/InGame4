using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject enemyCarrier;
    public int distanceFromCarrier;
    public GameObject prefab;
    public float timeToSpawn = 5, timeToStart = 7;

    private float elapsedTimeFromSpawn, elapsedTimeFromStart;
    public static bool[,] isAtThisLocationAlready;

    // Use this for initialization
    void Start()
    {
        isAtThisLocationAlready = new bool[40,4];
        for (int i = 0; i < 40; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                isAtThisLocationAlready[i, j] = false;
            }
        }
        dataUpdate();
        elapsedTimeFromSpawn = 0;
        elapsedTimeFromStart = 0;
    }

    // Update is called once per frame
    void Update()
    {
        dataUpdate();

        elapsedTimeFromSpawn += Time.deltaTime;
        elapsedTimeFromStart += Time.deltaTime;
        if (elapsedTimeFromSpawn > timeToSpawn)
        {
            elapsedTimeFromSpawn = 0;

            if (elapsedTimeFromStart > timeToStart) deployObstacle(Random.Range(1, 4));
        }
    }
    void dataUpdate()
    {
        this.GetComponent<EnemyPath>().speed = enemyCarrier.GetComponent<EnemyPath>().speed;
        this.GetComponent<EnemyPath>().current = (enemyCarrier.GetComponent<EnemyPath>().current + distanceFromCarrier) % 40;
    }

    void deployObstacle(int num)
    {
        num = Random.Range(1, 4);
        int currentPlace = this.GetComponent<EnemyPath>().current;

        Vector3 pos = this.GetComponent<Transform>().position;
        if (num == 1)
        {
            pos.y = 0;
        }
        if (num == 2)
        {
            pos.y = 2;
        }
        if (num == 3)
        {
            pos.y = 4;
        }
        Debug.Log(num + "! this is num");
        Debug.Log("position is: " + pos);
        Debug.Log(currentPlace +", " + num);
        if (isAtThisLocationAlready[currentPlace, num] == false)
        {
            GameObject.Instantiate(prefab, pos, Quaternion.identity);
            isAtThisLocationAlready[currentPlace, num] = true;
        }


    }
}
