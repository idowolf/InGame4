using System.Collections;
using UnityEngine;

public class BlinkArrowSpaceship : MonoBehaviour
{
    private bool OnLookAtSpaceship;
    public GameObject text;
    public GameObject text2;
    public Transform EnemyCarrier;
    private MeshRenderer renderer;
    public float distance = 1;
    public bool disableWhenTargetReached;
    public float blinkTime = 0.2f;
    private float elapsedTime;
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        float spY = EnemyCarrier.eulerAngles.y + (EnemyCarrier.eulerAngles.y < 0 ? 360 : 0);
        float myY = transform.eulerAngles.y + (transform.eulerAngles.y < 0 ? 360 : 0);
        Debug.Log(myY);
        if (Mathf.Abs(spY - myY) > distance)
        {
            OnLookAtSpaceship = false;
            text.SetActive(true);
            text2.SetActive(false);
            Vector3 rot = transform.eulerAngles;
            bool flg1 = ind(spY, 180, 360) && ind(myY, 180, 360) && myY < spY;
            bool flg2 = ind(spY, 0, 180) && ind(myY, 0, 180) && myY < spY;
            bool flg3 = ind(spY, 0, 180) && ind(myY, 180, 360) && myY - 180 > spY;
            bool flg4 = ind(spY, 180, 360) && ind(myY, 0, 180) && myY > spY - 180;

            if (flg1 || flg2 || flg3 || flg4)
                rot.z = 270;
            else
                rot.z = 90;
            transform.eulerAngles = rot;
            elapsedTime += Time.deltaTime;
            if (elapsedTime > blinkTime)
            {
                elapsedTime = 0;
                renderer.enabled = !renderer.enabled;
            }
        }
        else
        {
            text.SetActive(false);
            if (!OnLookAtSpaceship)
            {
                text2.SetActive(true);
                OnLookAtSpaceship = true;
            }
            renderer.enabled = false;
            if (disableWhenTargetReached)
            {
                Destroy(gameObject);
            }
        }
    }

    private bool ind(float deg, float low, float hi)
    {
        return deg >= low && deg <= hi;
    }
}
