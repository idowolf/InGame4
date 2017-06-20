using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereController : MonoBehaviour {
    public GameObject m_shotPrefab;
    public GameObject explosionSound;
    private Transform enemyUI;
    public GameObject explosionPrefab;
    public int currentPos, pathNum;
    bool destroyed;
    // Use this for initialization
    void Start () {
        enemyUI = GameObject.Find("EnemyUI").transform;
	}

    public void OnGaze()
    {
        StartCoroutine(DestroyMe());
    }

    IEnumerator DestroyMe()
    {
        GameObject go = GameObject.Instantiate(m_shotPrefab, enemyUI.position, enemyUI.rotation) as GameObject;
        yield return new WaitForSeconds(0.1f);

        Vector3 explosionPos = transform.position;
        Destroy(go);
        Instantiate(explosionPrefab, explosionPos, Quaternion.identity);
        Instantiate(explosionSound);
        SilentDestroyMe();

        if (gameObject)
            SilentDestroyMe();
    }
    public void SilentDestroyMe()
    {
        ObstacleManager.isAtThisLocationAlready[currentPos] = false;
        Destroy(gameObject);
    }
}
