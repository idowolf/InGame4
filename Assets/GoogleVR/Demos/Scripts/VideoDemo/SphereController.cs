using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereController : MonoBehaviour {
    public GameObject explosionSound;
    private Transform enemyUI;
    private float maxLifeTime;
    public GameObject explosionPrefab;
    public int currentPos, pathNum;
    bool destroyed;
    // Use this for initialization
    void Start () {
        maxLifeTime = 0;
        //StartCoroutine(DestroyInSixSeconds());
        enemyUI = GameObject.Find("EnemyUI").transform;
	}

    public void OnGaze()
    {
        DestroyMe();
    }
    IEnumerator DestroyInSixSeconds()
    {
        yield return new WaitForSeconds(6);
        if(gameObject)
            SilentDestroyMe();
    }

    public void DestroyMe()
    {
        Vector3 explosionPos = transform.position;
        Instantiate(explosionPrefab, explosionPos, Quaternion.identity);
        Instantiate(explosionSound);
        SilentDestroyMe();
    }

    public void SilentDestroyMe()
    {
        ObstacleManager.isAtThisLocationAlready[currentPos, pathNum] = false;
        Destroy(gameObject);
    }
}
