using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public int distanceFromCarrier;
    public GameObject prefab;
    public float timeToSpawn = 4;

    private float elapsedTimeFromSpawn;
    public static bool[] isAtThisLocationAlready;

    // Use this for initialization
    void Start()
    {
        isAtThisLocationAlready = new bool[40];
        elapsedTimeFromSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //elapsedTimeFromSpawn += Time.deltaTime;
        //if (elapsedTimeFromSpawn > timeToSpawn)
        //{
        //    elapsedTimeFromSpawn = 0;
            deployObstacle(Random.Range(1, 4));
        //}
    }

    void deployObstacle(int num)
    {
        num = Random.Range(1, 4);
        int currentPlace = (this.GetComponent<EnemyPath>().current + 15) % 40;

        Vector3 pos = this.GetComponent<Transform>().position;
        if (num == 1)
        {
            pos.y = 0;
        }
        if (num == 2)
        {
            pos.y = 1;
        }
        if (num == 3)
        {
            pos.y = 3;
        }
        if(currentPlace % 8 == 0)
        {
            if (isAtThisLocationAlready[currentPlace] == false)
            {
                isAtThisLocationAlready[currentPlace] = true;
                GameObject b = GameObject.Instantiate(prefab, pos, Quaternion.identity, GameObject.Find("EnemyContainer").transform);
                b.GetComponent<SphereController>().currentPos = currentPlace;
            }
        }
    }
}
