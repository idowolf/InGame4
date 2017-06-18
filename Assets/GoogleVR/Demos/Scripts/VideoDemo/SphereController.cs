using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereController : MonoBehaviour {
    private Transform enemyUI;
    private float maxLifeTime;
    public GameObject explosionPrefab;
    public int currentPos, pathNum;
    bool destroyed;
    // Use this for initialization
    void Start () {
        maxLifeTime = 0;
        StartCoroutine("DestroyInSixSeconds");
        enemyUI = GameObject.Find("EnemyUI").transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + Vector3.zero;
        maxLifeTime += Time.deltaTime;
        float thisX = this.transform.position.x;
        float otherX = enemyUI.position.x;
        if (thisX - otherX > 1)
        {
            if (!destroyed)
            {
                Destroy(gameObject, 2.0f);
            }
            ObstacleManager.isAtThisLocationAlready[currentPos, pathNum] = false;
            //Debug.Log("destroyed!");
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "EnemyUI")
        {
            Vector3 explosionPos = transform.position;
            Instantiate(explosionPrefab, explosionPos, Quaternion.identity);
            ObstacleManager.isAtThisLocationAlready[currentPos, pathNum] = false;
            if (!GameObject.Find("EnemyCarrier").GetComponent<PowerupManager>().IsPowerupActive(PowerupName.SHIELD))
            {
                destroyed = true;
                gameObject.transform.localScale = Vector3.zero;
                Destroy(other.gameObject);
                StartCoroutine(GameObject.Find("EnemyCarrier").GetComponent<Teleport>().DelayedChangeScene());
            }
        }
    }
    IEnumerator DestroyInSixSeconds()
    {
        yield return new WaitForSeconds(6);
        if (!destroyed)
        {
            ObstacleManager.isAtThisLocationAlready[currentPos, pathNum] = false;
            Destroy(gameObject);
        }
    }

}
