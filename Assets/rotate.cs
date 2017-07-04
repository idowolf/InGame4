using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rotate : MonoBehaviour {
    private float timer;
    private bool finished;
    public GameObject bomb;
    public GameObject enemy;
    public GameObject line;
    public GameObject player;
    public GameObject destroyAnimation;
    private Vector3 lookUp, inSpaceship, spaceshipRot;
	// Use this for initialization
	void Start () {
        lookUp = new Vector3(270, 0, 0);
        inSpaceship = new Vector3(0, -3.1f, -16.2f);
        spaceshipRot = new Vector3(-90, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (!finished)
        {
            if (timer < 2.7f)
            {
                transform.Rotate(0, Time.deltaTime * 750f, 0);
                bomb.transform.localScale += Vector3.one * 0.1f;
            }
            else if (Quaternion.Angle(transform.rotation,Quaternion.Euler(lookUp)) > 10)
            {
                transform.Rotate(0, Time.deltaTime * 200, 0);
            }
            else if (Vector3.Distance(bomb.transform.position, enemy.transform.position) > 0.1f)
            {
                bomb.transform.position = Vector3.MoveTowards(bomb.transform.position, enemy.transform.position, 1 * Time.deltaTime);
            }
            else
            {
                finished = true;
                GameObject.Instantiate(destroyAnimation, enemy.transform.position, Quaternion.identity);
                GameObject.Destroy(enemy);
                GameObject.Destroy(bomb);
                GameObject.Destroy(line);
            }
        }
        else if (Vector3.Distance(inSpaceship, player.transform.position) > float.Epsilon ||
            Quaternion.Angle(player.transform.rotation, Quaternion.Euler(spaceshipRot)) > 1)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, inSpaceship, Time.deltaTime * 2f);
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, Quaternion.Euler(spaceshipRot), 0.5f);

        }

        else
        {
            SceneManager.LoadScene("level1");
        }
	}
}
