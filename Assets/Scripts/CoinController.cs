using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {
    public static int AmountOfCoins = 0;
    private Transform enemyUI;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 6.0f);
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
            Destroy(this, 0.2f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "EnemyUI")
        {
            AmountOfCoins++;
            GameObject.Destroy(gameObject);
        }
    }

}
