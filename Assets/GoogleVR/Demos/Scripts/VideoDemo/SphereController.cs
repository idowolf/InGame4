using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereController : MonoBehaviour {
    private Transform enemyUI;
    private float maxLifeTime;
    public GameObject explosionPrefab;
    public int currentPos, pathNum;
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
            Destroy(gameObject,2.0f);
            ObstacleManager.isAtThisLocationAlready[currentPos, pathNum] = false;
            //Debug.Log("destroyed!");
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "EnemyUI")
        {
            Vector3 explosionPos = transform.position;
            Destroy(other.gameObject);
            Destroy(gameObject);
            ObstacleManager.isAtThisLocationAlready[currentPos, pathNum] = false;
            Instantiate(explosionPrefab, explosionPos, Quaternion.identity);
            SceneManager.LoadScene("level2", LoadSceneMode.Single);
        }
    }
    IEnumerator DestroyInSixSeconds()
    {
        yield return new WaitForSeconds(6);
        ObstacleManager.isAtThisLocationAlready[currentPos, pathNum] = false;
        Destroy(gameObject);
    }
}
