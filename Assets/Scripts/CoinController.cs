using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {
    public static int AmountOfCoins = 0;
    private Transform enemyUI;

    public int currentPos, pathNum;
    // Use this for initialization
    void Start()
    {
        StartCoroutine("DestroyInSixSeconds");
        enemyUI = GameObject.Find("EnemyUI").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.zero;
        float thisX = this.transform.position.x;
        float otherX = enemyUI.position.x;
        if (thisX - otherX > 1)
        {
            Destroy(gameObject, 0.2f);
            ObstacleManager.isAtThisLocationAlready[currentPos, pathNum] = false;
            //Debug.Log("destroyed!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision name = " + other.gameObject.name);
        if (other.gameObject.name == "EnemyUI")
        {
            AmountOfCoins++;
            GameObject.Destroy(gameObject);
            ObstacleManager.isAtThisLocationAlready[currentPos, pathNum] = false;
        }
    }
    IEnumerator DestroyInSixSeconds()
    {
        yield return new WaitForSeconds(6);
        ObstacleManager.isAtThisLocationAlready[currentPos, pathNum] = false;
        Destroy(gameObject);
    }

}
