using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinController : Spawnable {
    public static int AmountOfCoins = 0;
    private float maxLifeTime = 6f;
    protected Transform enemyUI;

    // Use this for initialization
    void Start()
    {
        maxLifeTime = 0;
        Destroy(gameObject, maxLifeTime);
        enemyUI = GameObject.Find("EnemyUI").transform;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.zero;
        maxLifeTime += Time.deltaTime;
        float thisX = this.transform.position.x;
        float otherX = enemyUI.position.x;
        if ((int)thisX == (int)otherX)
        {
            Destroy(this, 0.2f);
            //Debug.Log("destroyed!");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision name = " + other.gameObject.name);
        if (other.gameObject.name == "EnemyUI")
        {
            AmountOfCoins++;
            GameObject.Destroy(this);
        }
    }
}
