using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereController : MonoBehaviour {
    public GameObject m_shotPrefab;
    public GameObject explosionSound;
    private Transform enemyUI;
    public GameObject explosionPrefab;
    public int shotsCount;
    private float timeElapsed;
    public bool shooting;
    // Use this for initialization
    void Start () {
        enemyUI = GameObject.Find("EnemyUI").transform;
        timeElapsed = 1;
	}
    private void Update()
    {
        if (shooting)
        {
            timeElapsed += Time.deltaTime;
            if(timeElapsed > 0.1f)
            {
                timeElapsed = 0;
                shotsCount++;
                Vector3 goPosition = enemyUI.position;
                GameObject go = GameObject.Instantiate(m_shotPrefab, goPosition, enemyUI.rotation) as GameObject;
                Vector3 explosionPos = Camera.main.ScreenToWorldPoint(new Vector3(UnityEngine.VR.VRSettings.eyeTextureWidth / 2, UnityEngine.VR.VRSettings.eyeTextureHeight / 2, 15));
                //Vector3 explosionPos = transform.position;
                GetComponent<FloatObject>().degreesPerSecond += 5f;
                Instantiate(explosionPrefab, explosionPos, Quaternion.identity);
                Instantiate(explosionSound);
                GetComponent<HealthManager>().giveLife();
                GetComponent<MoveTowardsObject>().ProbeParent();
            }
        }
    }
    public void OnGazeEnter()
    {
        shooting = true;
    }
    public void OnGazeExit()
    {
        shooting = false;
        timeElapsed = 1;
    }

}
