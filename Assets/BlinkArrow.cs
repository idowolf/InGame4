using System.Collections;
using UnityEngine;

public class BlinkArrow : MonoBehaviour
{
    private MeshRenderer renderer;
    public float camRotMax = 300, camRotMin = 50;
    public bool fromMinToMax, disableWhenTargetReached;
    public float blinkTime = 0.2f;
    private float elapsedTime, camRotMiddle;
    void Start()
    {
        camRotMiddle = camRotMin + (camRotMax - camRotMin) / 2;
        renderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        float camRoty = Camera.main.transform.eulerAngles.y;
        bool flg;
        if (fromMinToMax)
            flg = camRoty > camRotMax || camRoty < camRotMin;
        else
            flg = camRoty < camRotMax && camRoty > camRotMin;
        if (flg)
        {
            Vector3 rot = transform.eulerAngles;
            if ((fromMinToMax && camRoty > camRotMax) || (!fromMinToMax && camRoty < camRotMiddle))
            {
                rot.z = 90;
            }
            else
            {
                rot.z = 270;
            }
            transform.eulerAngles = rot;
            elapsedTime += Time.deltaTime;
            if(elapsedTime > blinkTime)
            {
                elapsedTime = 0;
                renderer.enabled = !renderer.enabled;
            }
        }
        else
        {
            renderer.enabled = false;
            if (disableWhenTargetReached)
            {
                Destroy(gameObject);
            }
        }
    }
}
