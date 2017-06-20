using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {
    public GameObject soundPrefab;
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
            Destroy(gameObject, 2.0f);
            ObstacleManager.isAtThisLocationAlready[currentPos] = false;
            //Debug.Log("destroyed!");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "EnemyUI" || other.gameObject.name == "Magnet")
        {
            AmountOfCoins++;
            GameObject.Instantiate(soundPrefab);
            GameObject.Destroy(gameObject);
            ObstacleManager.isAtThisLocationAlready[currentPos] = false;
        }
    }
    IEnumerator DestroyInSixSeconds()
    {
        yield return new WaitForSeconds(6);
        ObstacleManager.isAtThisLocationAlready[currentPos] = false;
        Destroy(gameObject);
    }

}
