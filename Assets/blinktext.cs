using System.Collections;
using UnityEngine;

public class blinktext : MonoBehaviour
{
    public float blinkTime = 0.2f;
    private float elapsedTime;
    void Start()
    {
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > blinkTime)
        {
            elapsedTime = 0;
            GetComponent<Canvas>().enabled = !GetComponent<Canvas>().enabled;
        }
    }
}
