using System.Collections;
using UnityEngine;

public class BlinkArrowSpaceship : MonoBehaviour
{
    private bool OnLookAtSpaceship;
    private Transform astro;
    public Transform EnemyContainer;
    public Transform cam;
    private MeshRenderer renderer;
    public float distance = 1;
    public float blinkTime = 0.2f;
    private float elapsedTime;
    private float low = 0, mid = 180, high = 360;
    void Start()
    {
        cam = Camera.main.transform;
        renderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (EnemyContainer.childCount > 0)
        {
            astro = EnemyContainer.GetChild(0);
            float arrowX = Mathf.Atan2(cam.forward.z, cam.forward.x) * Mathf.Rad2Deg;
            arrowX += (arrowX < 0 ? 360 : 0);
            float astroX = Mathf.Atan2(astro.position.z - cam.position.z, astro.position.x - cam.position.x) * Mathf.Rad2Deg;
            astroX += (astroX < 0 ? 360 : 0);
            if (Mathf.Abs(arrowX - astroX) > distance)
            {
                OnLookAtSpaceship = false;
                Vector3 rot = transform.eulerAngles;
                bool flg1 = ind(arrowX, mid, high) && ind(astroX, mid, high) && astroX < arrowX;
                bool flg2 = ind(arrowX, low, mid) && ind(astroX, low, mid) && astroX < arrowX;
                bool flg3 = ind(arrowX, low, mid) && ind(astroX, mid, high) && astroX - mid > arrowX;
                bool flg4 = ind(arrowX, mid, high) && ind(astroX, low, mid) && astroX > arrowX - mid;

                if (flg1 || flg2 || flg3 || flg4)
                    rot.z = 270; // point right
                else
                    rot.z = 90; // point left
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
                if (!OnLookAtSpaceship)
                {
                    OnLookAtSpaceship = true;
                }
                renderer.enabled = false;
            }

        }
        else
        {
            renderer.enabled = false;
        }
    }

    private bool ind(float deg, float low, float hi)
    {
        return deg >= low && deg <= hi;
    }
}
