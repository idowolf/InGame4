using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShieldPowerupController : MonoBehaviour
{
    public float duration = 5;
    private Transform enemyUI;
    private float maxLifeTime;

    public int currentPos, pathNum;
    // Use this for initialization
    void Start()
    {
        maxLifeTime = 0;
        StartCoroutine("DestroyInSixSeconds");
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
            Destroy(gameObject, 2.0f);
            ObstacleManager.isAtThisLocationAlready[currentPos] = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "EnemyUI" || other.gameObject.name == "Magnet")
        {
            GameObject.Find("EnemyCarrier").GetComponent<PowerupManager>().ActivatePowerup(PowerupName.SHIELD, duration);
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