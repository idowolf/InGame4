using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour {
    private Transform enemyUI;
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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision name = " + other.gameObject.name);
        if (other.gameObject.name == "EnemyUI")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision name = " + collision.gameObject.name);
        if (collision.gameObject.name == "EnemyUI")
        {
            Destroy(collision.gameObject);
        }
    }
}
