﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereController : MonoBehaviour {
    public GameObject m_shotPrefab;
    public GameObject explosionSound;
    private Transform enemyUI;
    public float comingToYouSpeed = 1;
    public GameObject explosionPrefab;
    public int currentPos, pathNum;
    bool destroyed;
    // Use this for initialization
    void Start () {
        enemyUI = GameObject.Find("EnemyUI").transform;
	}
    private void Update()
    {
    }
    public void OnGaze()
    {
        StartCoroutine(DestroyMe());
    }

    IEnumerator DestroyMe()
    {
        Vector3 goPosition = enemyUI.position;
        GameObject go = GameObject.Instantiate(m_shotPrefab, goPosition, enemyUI.rotation) as GameObject;
        yield return new WaitForSeconds(0.1f);
        Vector3 explosionPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 20));
        Instantiate(explosionPrefab, explosionPos, Quaternion.identity);
        Instantiate(explosionSound);
        GetComponent<MoveTowardsObject>().ProbeParent();
    }
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(DestroyMe());
    }
}
