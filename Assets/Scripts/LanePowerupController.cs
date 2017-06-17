using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanePowerupController : MonoBehaviour {

    public float duration = 5;
    private Transform enemyUI;
    private float maxLifeTime;
    // Use this for initialization
    void Start()
    {
        maxLifeTime = 0;
        Destroy(gameObject, 6.0f);
        enemyUI = GameObject.Find("EnemyUI").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.zero;
        maxLifeTime += Time.deltaTime;
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
            GameObject.Find("EnemyCarrier").GetComponent<PowerupManager>().ActivatePowerup(PowerupName.LANE, duration);
            GameObject.Destroy(gameObject);
        }
    }
}
