using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BonusManager : MonoBehaviour {
    public GameObject coin;
    Vector3[] vectorArray;

    public float timeToZero;
	// Use this for initialization
	void Start () {
        /*vectorArray = PointsOnSphere(150);
        for (int i = 0; i< vectorArray.Length;i++)
        {
            Instantiate(coin, vectorArray[i],Quaternion.identity);
        }*/
        
	}
	
	// Update is called once per frame
	void Update () {
        timeToZero -= Time.deltaTime;
        if (timeToZero <= 0)
        {
            SceneManager.LoadScene("gameOverScene");
        }
        {

        }
	}

    Vector3[] PointsOnSphere(int n)
    {
        List<Vector3> upts = new List<Vector3>();
        float inc = Mathf.PI * (3 - Mathf.Sqrt(5));
        float off = 2.0f / n;
        float x = 0;
        float y = 0;
        float z = 0;
        float r = 0;
        float phi = 0;

        for (int k = 0; k < n; k++)
        {
            y = k * off - 1 + (off / 2);
            r = Mathf.Sqrt(1 - y * y);
            phi = k * inc*3;
            x = Mathf.Cos(phi) * r;
            z = Mathf.Sin(phi) * r;

            upts.Add(new Vector3(x, y, z)*2.2f);
        }
        Vector3[] pts = upts.ToArray();
        return pts;
    }
}
