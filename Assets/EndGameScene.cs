using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScene : MonoBehaviour
{
    public float rotationSpeed = 1f, shootSpeed = 1f;
    private float timer;
    private bool activated;
    public GameObject bomb;
    public GameObject enemy;
    public GameObject line;
    public GameObject player;
    public GameObject destroyAnimation;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            if(enemy && bomb)
            {
                bomb.transform.parent = null;
                if (Vector3.Distance(enemy.transform.position, bomb.transform.position) > 0.1f)
                {
                    if(line) Destroy(line);
                    bomb.transform.position = Vector3.MoveTowards(bomb.transform.position, enemy.transform.position, shootSpeed * Time.deltaTime);
                }
                else
                {
                    GameObject.Instantiate(destroyAnimation,enemy.transform.position,Quaternion.identity);
                    Destroy(bomb);
                    Destroy(enemy);
                }
            }
            else
            {
                timer += Time.deltaTime;
                if (timer > destroyAnimation.GetComponent<ParticleSystem>().main.duration)
                {
                    SceneManager.LoadScene("gameOverScene");
                }
            }
        }
    }

    public void Activate()
    {
        activated = true;
    }
}
